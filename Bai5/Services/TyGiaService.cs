using System.Collections.Concurrent;
using System.Text.Json;
using Bai5.Helpers;
using Serilog;

namespace Bai5.Services;

/// <summary>Kết quả một lần lấy tỷ giá ngoại tệ → VND.</summary>
public sealed record KetQuaTyGia(
    string NgoaiTe,          // THB, KRW, JPY, USD
    decimal TyGia,           // 1 đơn vị ngoại tệ = ? VND
    string NgayDuLieu,       // trường "date" API trả về
    string Url,              // địa chỉ đã dùng
    bool LaNguonDuPhong,     // true nếu phải dùng địa chỉ dự phòng
    DateTime ThoiDiemLay,
    bool TuBoNhoDem);

/// <summary>Cả địa chỉ chính và dự phòng đều lỗi.</summary>
public sealed class TyGiaException : Exception
{
    public TyGiaException(string message, Exception? inner) : base(message, inner) { }
}

public static class TyGiaService
{
    // Một HttpClient dùng chung cho cả ứng dụng
    private static readonly HttpClient _http = new()
    {
        Timeout = TimeSpan.FromSeconds(Math.Clamp(AppConfig.ExchangeRate.TimeoutSeconds, 2, 60))
    };

    // Bộ nhớ đệm trong RAM: mã ngoại tệ → kết quả (hết hạn sau CacheMinutes phút)
    private static readonly ConcurrentDictionary<string, KetQuaTyGia> _cache = new();

    /// <summary>Lấy tỷ giá 1 ngoại tệ → VND (theo đúng yêu cầu đề bài).</summary>
    public static async Task<decimal> LayTyGiaAsync(string ngoaiTe)
    {
        return (await LayTyGiaChiTietAsync(ngoaiTe)).TyGia;
    }

    /// <summary>Lấy tỷ giá kèm thông tin nguồn; thử địa chỉ chính rồi tới địa chỉ dự phòng.</summary>
    public static async Task<KetQuaTyGia> LayTyGiaChiTietAsync(string ngoaiTe, bool boQuaCache = false)
    {
        if (string.IsNullOrWhiteSpace(ngoaiTe))
            throw new ArgumentException("Thiếu mã ngoại tệ.", nameof(ngoaiTe));

        string code = ngoaiTe.Trim().ToLowerInvariant();
        var hanCache = TimeSpan.FromMinutes(Math.Max(0, AppConfig.ExchangeRate.CacheMinutes));

        // 1) Còn trong bộ nhớ đệm thì dùng lại, không gọi API
        if (!boQuaCache
            && _cache.TryGetValue(code, out var daLuu)
            && DateTime.Now - daLuu.ThoiDiemLay < hanCache)
        {
            Log.Debug("Dùng tỷ giá {NgoaiTe} từ bộ nhớ đệm (lấy lúc {ThoiDiem:HH:mm:ss})", daLuu.NgoaiTe, daLuu.ThoiDiemLay);
            return daLuu with { TuBoNhoDem = true };
        }

        // 2) Thử lần lượt địa chỉ chính → dự phòng
        var danhSachNguon = new (string Url, bool DuPhong)[]
        {
            (AppConfig.ExchangeRate.PrimaryUrl, false),
            (AppConfig.ExchangeRate.FallbackUrl, true)
        };

        Exception? loiCuoi = null;
        foreach (var (mauUrl, duPhong) in danhSachNguon)
        {
            if (string.IsNullOrWhiteSpace(mauUrl)) continue;

            string url = TaoUrl(mauUrl, code);
            try
            {
                var (tyGia, ngay) = await GoiApiAsync(url, code);
                var ketQua = new KetQuaTyGia(code.ToUpperInvariant(), tyGia, ngay, url, duPhong, DateTime.Now, false);
                _cache[code] = ketQua;

                Log.Information("Lấy tỷ giá {NgoaiTe}->VND = {TyGia} (dữ liệu ngày {Ngay}) từ địa chỉ {LoaiNguon}: {Url}",
                    ketQua.NgoaiTe, tyGia, ngay, duPhong ? "DỰ PHÒNG" : "CHÍNH", url);
                return ketQua;
            }
            catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException or JsonException
                                           or KeyNotFoundException or InvalidOperationException or FormatException)
            {
                loiCuoi = ex;
                if (!duPhong)
                    Log.Warning("Địa chỉ chính lỗi ({LyDo}) – chuyển sang địa chỉ dự phòng. URL: {Url}", ex.Message, url);
                else
                    Log.Error(ex, "Địa chỉ dự phòng cũng lỗi ({LyDo}). URL: {Url}", ex.Message, url);
            }
        }

        throw new TyGiaException(
            "Không lấy được tỷ giá từ cả địa chỉ chính và địa chỉ dự phòng.\nVui lòng kiểm tra kết nối mạng rồi thử lại.",
            loiCuoi);
    }

    /// <summary>Xóa bộ nhớ đệm (dùng khi bấm "Tải lại tỷ giá").</summary>
    public static void XoaBoNhoDem() => _cache.Clear();

    private static string TaoUrl(string mauUrl, string code)
    {
        // Cho phép cấu hình dạng ".../currencies/{code}.json" hoặc chỉ ".../v1/"
        return mauUrl.Contains("{code}")
            ? mauUrl.Replace("{code}", code)
            : $"{mauUrl.TrimEnd('/')}/currencies/{code}.json";
    }

    private static async Task<(decimal TyGia, string Ngay)> GoiApiAsync(string url, string code)
    {
        using HttpResponseMessage resp = await _http.GetAsync(url);
        resp.EnsureSuccessStatusCode();

        string json = await resp.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // Dạng dữ liệu: {"date":"2026-10-19","thb":{"vnd":752.35, ...}}
        JsonElement vnd = root.GetProperty(code).GetProperty("vnd");
        decimal tyGia = vnd.TryGetDecimal(out decimal d) ? d : (decimal)vnd.GetDouble();
        if (tyGia <= 0)
            throw new InvalidOperationException("Tỷ giá trả về không hợp lệ.");

        string ngay = root.TryGetProperty("date", out JsonElement date) ? date.GetString() ?? "" : "";
        return (Math.Round(tyGia, 4), ngay);
    }
}
