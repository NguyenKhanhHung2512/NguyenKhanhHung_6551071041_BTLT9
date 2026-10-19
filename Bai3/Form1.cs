using System.Globalization;
using System.Text.Json;
using Bai3.Helpers;
using Bai3.Models;
using Bai3.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bai3;

public partial class Form1 : Form
{
    private enum KetQuaThoiTiet { ChuaXem, CoDuBao, NgoaiKhungDuBao, KhongTimThayDiaDiem, LoiMang }

    // Phương tiện luôn lưu tiếng Việt trong CSDL, chỉ đổi chữ hiển thị theo ngôn ngữ
    private static readonly string[] PhuongTienVi = { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" };
    private static readonly string[] PhuongTienEn = { "Motorbike", "Car", "Coach", "Train" };
    private static readonly Color NenThuong = Color.FromArgb(241, 248, 246);
    private static readonly Color NenCanhBao = Color.FromArgb(255, 204, 128);   // cam: khả năng mưa cao

    private List<ChuyenDi> _dsChuyen = new();
    private int? _maDangChon;
    private bool _dangNap;
    private bool _dangKhoiTao = true;
    private bool _en;

    // Trạng thái khung thời tiết (giữ lại để vẽ lại khi đổi ngôn ngữ, không cần gọi API lại)
    private int _phienThoiTiet;
    private KetQuaThoiTiet _ketQua = KetQuaThoiTiet.ChuaXem;
    private WeatherForecast? _duBao;
    private string _diaDiemDuBao = "";
    private DateTime _ngayDuBao;

    public Form1()
    {
        InitializeComponent();
        _en = UserSettings.LoadLanguage() == "en";
        cboNgonNgu.SelectedIndex = _en ? 1 : 0;
        TaoCotLuoi();
        ApDungNgonNgu();
        LamMoiO();
        _dangKhoiTao = false;
    }

    private async void Form1_Shown(object? sender, EventArgs e)
    {
        await NapDanhSachAsync();
    }

    // ===================== NGÔN NGỮ =====================

    private CultureInfo VanHoa => CultureInfo.GetCultureInfo(_en ? "en-US" : "vi-VN");

    private string T(string english, string tiengViet) => _en ? english : tiengViet;

    private string Tien(decimal soTien) =>
        _en ? soTien.ToString("N0", VanHoa) + " VND" : soTien.ToString("N0", VanHoa) + " đ";

    private async void CboNgonNgu_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangKhoiTao) return;
        _en = cboNgonNgu.SelectedIndex == 1;
        UserSettings.SaveLanguage(_en ? "en" : "vi");   // lưu vào %LocalAppData%\KeHoachDaNgoai\usersettings.json
        Log.Information("Đổi ngôn ngữ giao diện sang {NgonNgu}", _en ? "English" : "Tiếng Việt");
        ApDungNgonNgu();
        await NapDanhSachAsync();   // định dạng lại ngày / tiền trong lưới
    }

    private void ApDungNgonNgu()
    {
        Thread.CurrentThread.CurrentCulture = VanHoa;
        Thread.CurrentThread.CurrentUICulture = VanHoa;

        string tieuDe = T("Picnic Planner", "Kế hoạch dã ngoại");
        Text = $"{tieuDe} - v{typeof(Program).Assembly.GetName().Version?.ToString(3)}";
        lblTieuDe.Text = tieuDe;
        lblNgonNgu.Text = T("Language:", "Ngôn ngữ:");

        grpThongTin.Text = T("Trip details", "Thông tin chuyến đi");
        lblTenChuyen.Text = T("Trip name:", "Tên chuyến:");
        lblDiaDiem.Text = T("Destination:", "Địa điểm:");
        lblPhuongTien.Text = T("Transport:", "Phương tiện:");
        chkDaHoanThanh.Text = T("Completed", "Đã hoàn thành");
        lblNgayDi.Text = T("Departure:", "Ngày đi:");
        lblSoNguoi.Text = T("Travelers:", "Số người:");
        lblNganSach.Text = T("Budget (VND):", "Ngân sách (đ):");
        lblGhiChu.Text = T("Notes:", "Ghi chú:");
        btnThem.Text = T("Add", "Thêm");
        btnSua.Text = T("Edit", "Sửa");
        btnXoa.Text = T("Delete", "Xóa");
        btnLamMoi.Text = T("Clear", "Làm mới");

        grpThoiTiet.Text = T("Weather on departure day", "Thời tiết ngày đi");
        btnXemThoiTiet.Text = T("View weather", "Xem thời tiết");

        txtTim.PlaceholderText = T("Search trip name or destination", "Tìm tên chuyến hoặc địa điểm");
        chkChuaHoanThanh.Text = T("Only unfinished trips", "Chỉ hiện chuyến chưa hoàn thành");
        lblTu.Text = T("From:", "Từ ngày:");
        lblDen.Text = T("To:", "Đến ngày:");
        btnTim.Text = T("Search", "Tìm");
        btnBoLoc.Text = T("Clear filter", "Bỏ lọc");

        // Định dạng ngày theo CultureInfo
        string dinhDangNgay = VanHoa.DateTimeFormat.ShortDatePattern;
        dtpNgayDi.CustomFormat = dinhDangNgay;
        dtpTu.CustomFormat = dinhDangNgay;
        dtpDen.CustomFormat = dinhDangNgay;

        // Phương tiện: giữ nguyên vị trí đang chọn
        int chon = Math.Max(0, cboPhuongTien.SelectedIndex);
        cboPhuongTien.Items.Clear();
        cboPhuongTien.Items.AddRange(_en ? PhuongTienEn : PhuongTienVi);
        cboPhuongTien.SelectedIndex = chon;

        // Tiêu đề cột lưới
        string[] cotVi = { "Mã", "Tên chuyến", "Địa điểm", "Ngày đi", "Số người", "Ngân sách", "Phương tiện", "Hoàn thành" };
        string[] cotEn = { "ID", "Trip", "Destination", "Date", "People", "Budget", "Transport", "Completed" };
        for (int i = 0; i < dgvChuyenDi.Columns.Count && i < cotVi.Length; i++)
            dgvChuyenDi.Columns[i].HeaderText = _en ? cotEn[i] : cotVi[i];

        HienThiThoiTiet();
    }

    // ===================== DANH SÁCH + LỌC =====================

    private void TaoCotLuoi()
    {
        dgvChuyenDi.Columns.Add("MaChuyen", "Mã");
        dgvChuyenDi.Columns.Add("TenChuyen", "Tên chuyến");
        dgvChuyenDi.Columns.Add("DiaDiem", "Địa điểm");
        dgvChuyenDi.Columns.Add("NgayDi", "Ngày đi");
        dgvChuyenDi.Columns.Add("SoNguoi", "Số người");
        dgvChuyenDi.Columns.Add("NganSach", "Ngân sách");
        dgvChuyenDi.Columns.Add("PhuongTien", "Phương tiện");
        dgvChuyenDi.Columns.Add(new DataGridViewCheckBoxColumn { Name = "DaHoanThanh", HeaderText = "Hoàn thành" });

        dgvChuyenDi.Columns["MaChuyen"]!.FillWeight = 40;
        dgvChuyenDi.Columns["TenChuyen"]!.FillWeight = 200;
        dgvChuyenDi.Columns["SoNguoi"]!.FillWeight = 60;
        dgvChuyenDi.Columns["DaHoanThanh"]!.FillWeight = 70;
        dgvChuyenDi.Columns["SoNguoi"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvChuyenDi.Columns["NganSach"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    private async Task NapDanhSachAsync()
    {
        if (_dangNap || IsDisposed) return;
        _dangNap = true;
        try
        {
            using var db = DbContextHelper.GetContext();
            IQueryable<ChuyenDi> q = db.ChuyenDis.AsNoTracking();

            string tuKhoa = txtTim.Text.Trim();
            if (tuKhoa.Length > 0)
                q = q.Where(x => x.TenChuyen.Contains(tuKhoa) || x.DiaDiem.Contains(tuKhoa));
            if (chkChuaHoanThanh.Checked)
                q = q.Where(x => !x.DaHoanThanh);
            if (dtpTu.Checked)
            {
                var tu = DateOnly.FromDateTime(dtpTu.Value.Date);
                q = q.Where(x => x.NgayDi >= tu);
            }
            if (dtpDen.Checked)
            {
                var den = DateOnly.FromDateTime(dtpDen.Value.Date);
                q = q.Where(x => x.NgayDi <= den);
            }

            _dsChuyen = await q.OrderBy(x => x.NgayDi).ToListAsync();

            dgvChuyenDi.Rows.Clear();
            foreach (var c in _dsChuyen)
            {
                dgvChuyenDi.Rows.Add(c.MaChuyen, c.TenChuyen, c.DiaDiem,
                    c.NgayDi.ToDateTime(TimeOnly.MinValue).ToString("d", VanHoa),
                    c.SoNguoi, Tien(c.NganSach), TenPhuongTien(c.PhuongTien), c.DaHoanThanh);
            }
            dgvChuyenDi.ClearSelection();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Không tải được danh sách chuyến đi");
            ThongBao(T("Could not load trips. Please check the database connection.",
                       "Không tải được danh sách chuyến đi. Hãy kiểm tra kết nối cơ sở dữ liệu."), MessageBoxIcon.Error);
        }
        finally
        {
            _dangNap = false;
        }
    }

    private string TenPhuongTien(string giaTriCsdl)
    {
        int i = Array.IndexOf(PhuongTienVi, giaTriCsdl);
        return i >= 0 && _en ? PhuongTienEn[i] : giaTriCsdl;
    }

    private async void BoLocThayDoi(object? sender, EventArgs e)
    {
        if (_dangKhoiTao) return;
        await NapDanhSachAsync();
    }

    private async void BtnTim_Click(object? sender, EventArgs e)
    {
        await NapDanhSachAsync();
    }

    private async void TxtTim_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        await NapDanhSachAsync();
    }

    private async void BtnBoLoc_Click(object? sender, EventArgs e)
    {
        _dangKhoiTao = true;   // tắt tạm sự kiện để chỉ nạp 1 lần
        txtTim.Clear();
        chkChuaHoanThanh.Checked = false;
        dtpTu.Checked = false;
        dtpDen.Checked = false;
        _dangKhoiTao = false;
        await NapDanhSachAsync();
    }

    private void DgvChuyenDi_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dangNap || dgvChuyenDi.CurrentRow == null || !dgvChuyenDi.CurrentRow.Selected) return;

        int ma = Convert.ToInt32(dgvChuyenDi.CurrentRow.Cells["MaChuyen"].Value);
        var c = _dsChuyen.FirstOrDefault(x => x.MaChuyen == ma);
        if (c == null) return;

        _maDangChon = c.MaChuyen;
        txtTenChuyen.Text = c.TenChuyen;
        txtDiaDiem.Text = c.DiaDiem;
        dtpNgayDi.Value = c.NgayDi.ToDateTime(TimeOnly.MinValue);
        nudSoNguoi.Value = Math.Clamp(c.SoNguoi, (int)nudSoNguoi.Minimum, (int)nudSoNguoi.Maximum);
        nudNganSach.Value = Math.Clamp(c.NganSach, nudNganSach.Minimum, nudNganSach.Maximum);
        cboPhuongTien.SelectedIndex = Math.Max(0, Array.IndexOf(PhuongTienVi, c.PhuongTien));
        chkDaHoanThanh.Checked = c.DaHoanThanh;
        txtGhiChu.Text = c.GhiChu ?? "";

        // Chọn chuyến khác thì xóa kết quả thời tiết cũ
        _phienThoiTiet++;
        _ketQua = KetQuaThoiTiet.ChuaXem;
        btnXemThoiTiet.Enabled = true;
        prgThoiTiet.Visible = false;
        HienThiThoiTiet();
    }

    private async void DgvChuyenDi_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) await XemThoiTietAsync();
    }

    // ===================== THÊM / SỬA / XÓA =====================

    private bool KiemTraHopLe(bool laThemMoi)
    {
        if (string.IsNullOrWhiteSpace(txtTenChuyen.Text) || string.IsNullOrWhiteSpace(txtDiaDiem.Text))
        {
            ThongBao(T("Trip name and destination are required.", "Tên chuyến và địa điểm không được để trống."));
            return false;
        }
        if (laThemMoi && dtpNgayDi.Value.Date < DateTime.Today)
        {
            ThongBao(T("The departure date cannot be in the past.", "Ngày đi không được nhỏ hơn hôm nay."));
            return false;
        }
        if (nudSoNguoi.Value < 1 || nudNganSach.Value < 0)
        {
            ThongBao(T("Travelers must be at least 1 and budget cannot be negative.",
                       "Số người phải từ 1 trở lên và ngân sách không được âm."));
            return false;
        }
        return true;
    }

    private void GanDuLieu(ChuyenDi c)
    {
        c.TenChuyen = txtTenChuyen.Text.Trim();
        c.DiaDiem = txtDiaDiem.Text.Trim();
        c.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
        c.SoNguoi = (int)nudSoNguoi.Value;
        c.NganSach = nudNganSach.Value;
        c.PhuongTien = PhuongTienVi[Math.Max(0, cboPhuongTien.SelectedIndex)];
        c.DaHoanThanh = chkDaHoanThanh.Checked;
        string ghiChu = txtGhiChu.Text.Trim();
        c.GhiChu = ghiChu.Length == 0 ? null : ghiChu;
    }

    private async void BtnThem_Click(object? sender, EventArgs e)
    {
        if (!KiemTraHopLe(laThemMoi: true)) return;
        try
        {
            using var db = DbContextHelper.GetContext();
            var c = new ChuyenDi();
            GanDuLieu(c);
            db.ChuyenDis.Add(c);
            await db.SaveChangesAsync();
            Log.Information("Thêm chuyến đi {MaChuyen} - {TenChuyen}", c.MaChuyen, c.TenChuyen);
            LamMoiO();
            await NapDanhSachAsync();
        }
        catch (Exception ex)
        {
            LoiCsdl(ex, "thêm chuyến đi");
        }
    }

    private async void BtnSua_Click(object? sender, EventArgs e)
    {
        if (_maDangChon == null)
        {
            ThongBao(T("Select a trip to edit.", "Hãy chọn chuyến đi cần sửa."));
            return;
        }
        if (!KiemTraHopLe(laThemMoi: false)) return;
        try
        {
            using var db = DbContextHelper.GetContext();
            var c = await db.ChuyenDis.FindAsync(_maDangChon.Value);
            if (c == null)
            {
                ThongBao(T("This trip no longer exists.", "Chuyến đi này không còn tồn tại."));
                await NapDanhSachAsync();
                return;
            }
            GanDuLieu(c);
            await db.SaveChangesAsync();
            Log.Information("Sửa chuyến đi {MaChuyen} - {TenChuyen}", c.MaChuyen, c.TenChuyen);
            LamMoiO();
            await NapDanhSachAsync();
        }
        catch (Exception ex)
        {
            LoiCsdl(ex, "sửa chuyến đi");
        }
    }

    private async void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_maDangChon == null)
        {
            ThongBao(T("Select a trip to delete.", "Hãy chọn chuyến đi cần xóa."));
            return;
        }
        if (MessageBox.Show(this, T("Delete the selected trip?", "Bạn có chắc muốn xóa chuyến đi này?"),
                T("Confirm", "Xác nhận"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;
        try
        {
            using var db = DbContextHelper.GetContext();
            var c = await db.ChuyenDis.FindAsync(_maDangChon.Value);
            if (c != null)
            {
                db.ChuyenDis.Remove(c);
                await db.SaveChangesAsync();
                Log.Information("Xóa chuyến đi {MaChuyen} - {TenChuyen}", c.MaChuyen, c.TenChuyen);
            }
            LamMoiO();
            await NapDanhSachAsync();
        }
        catch (Exception ex)
        {
            LoiCsdl(ex, "xóa chuyến đi");
        }
    }

    private async void BtnLamMoi_Click(object? sender, EventArgs e)
    {
        LamMoiO();
        await NapDanhSachAsync();
    }

    private void LamMoiO()
    {
        _maDangChon = null;
        txtTenChuyen.Clear();
        txtDiaDiem.Clear();
        dtpNgayDi.Value = DateTime.Today;
        nudSoNguoi.Value = 1;
        nudNganSach.Value = 0;
        cboPhuongTien.SelectedIndex = 0;
        chkDaHoanThanh.Checked = false;
        txtGhiChu.Clear();
        dgvChuyenDi.ClearSelection();

        _phienThoiTiet++;
        _ketQua = KetQuaThoiTiet.ChuaXem;
        btnXemThoiTiet.Enabled = true;
        prgThoiTiet.Visible = false;
        HienThiThoiTiet();
    }

    // ===================== THỜI TIẾT =====================

    private async void BtnXemThoiTiet_Click(object? sender, EventArgs e)
    {
        await XemThoiTietAsync();
    }

    private async Task XemThoiTietAsync()
    {
        string diaDiem = txtDiaDiem.Text.Trim();
        if (diaDiem.Length == 0)
        {
            ThongBao(T("Enter a destination first.", "Hãy nhập địa điểm cần xem thời tiết."));
            return;
        }

        int phien = ++_phienThoiTiet;
        _diaDiemDuBao = diaDiem;
        _ngayDuBao = dtpNgayDi.Value.Date;

        // Khóa nút + hiện ProgressBar kiểu Marquee trong lúc tải
        btnXemThoiTiet.Enabled = false;
        prgThoiTiet.Visible = true;
        lblTrangThai.Text = T("Loading forecast…", "Đang tải dự báo…");

        try
        {
            var duBao = await WeatherService.GetForecastAsync(diaDiem, _ngayDuBao, _en ? "en" : "vi");
            if (phien != _phienThoiTiet) return;   // người dùng đã chọn chuyến khác

            _duBao = duBao;
            _ketQua = duBao == null ? KetQuaThoiTiet.NgoaiKhungDuBao : KetQuaThoiTiet.CoDuBao;
            if (duBao != null)
                Log.Information("Dự báo {DiaDiem} ngày {Ngay:dd/MM/yyyy}: code {Code}, {Min}-{Max}°C, mưa {Mua}%",
                    diaDiem, _ngayDuBao, duBao.Code, duBao.Min, duBao.Max, duBao.Rain);
        }
        catch (LocationNotFoundException)
        {
            if (phien != _phienThoiTiet) return;
            _ketQua = KetQuaThoiTiet.KhongTimThayDiaDiem;
            Log.Information("Không tìm thấy địa danh {DiaDiem}", diaDiem);
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException or JsonException
                                       or InvalidOperationException or KeyNotFoundException)
        {
            if (phien != _phienThoiTiet) return;
            _ketQua = KetQuaThoiTiet.LoiMang;
            Log.Warning(ex, "Gọi API thời tiết thất bại cho {DiaDiem}", diaDiem);
        }
        finally
        {
            if (phien == _phienThoiTiet)
            {
                btnXemThoiTiet.Enabled = true;
                prgThoiTiet.Visible = false;
                HienThiThoiTiet();
            }
        }
    }

    /// <summary>Vẽ lại khung thời tiết theo trạng thái hiện tại và ngôn ngữ đang chọn.</summary>
    private void HienThiThoiTiet()
    {
        pnlKetQua.BackColor = NenThuong;
        lblLoiKhuyen.Text = "";
        string tieuDe = $"{_diaDiemDuBao} – {_ngayDuBao.ToString("d", VanHoa)}";

        switch (_ketQua)
        {
            case KetQuaThoiTiet.CoDuBao when _duBao != null:
                lblTieuDeThoiTiet.Text = tieuDe;
                lblIcon.Text = BieuTuong(_duBao.Code);
                lblChiTiet.Text = MoTaThoiTiet(_duBao.Code) + "\n"
                    + T("Low – High: ", "Thấp nhất – cao nhất: ") + $"{_duBao.Min:0}°C – {_duBao.Max:0}°C\n"
                    + T("Chance of rain: ", "Xác suất mưa: ") + $"{_duBao.Rain}%";
                if (_duBao.Rain >= 60)
                {
                    pnlKetQua.BackColor = NenCanhBao;
                    lblLoiKhuyen.Text = T("Bring a raincoat or consider rescheduling.", "Nên mang áo mưa hoặc cân nhắc dời lịch.");
                }
                lblTrangThai.Text = T("Source: Open-Meteo", "Nguồn: Open-Meteo");
                break;

            case KetQuaThoiTiet.NgoaiKhungDuBao:
                lblTieuDeThoiTiet.Text = tieuDe;
                lblIcon.Text = "📅";
                lblChiTiet.Text = T("No forecast data yet.", "Chưa có dữ liệu dự báo.");
                lblTrangThai.Text = T("Forecasts are only available for the next 16 days.", "Dự báo chỉ có trong 16 ngày tới.");
                break;

            case KetQuaThoiTiet.KhongTimThayDiaDiem:
                lblTieuDeThoiTiet.Text = T("Destination not found", "Không tìm thấy địa danh");
                lblIcon.Text = "❓";
                lblChiTiet.Text = T($"No place matched \"{_diaDiemDuBao}\".", $"Không tìm thấy \"{_diaDiemDuBao}\".");
                lblTrangThai.Text = T("Try the name without accents, e.g. \"Da Lat\".", "Thử nhập tên không dấu, ví dụ \"Da Lat\".");
                break;

            case KetQuaThoiTiet.LoiMang:
                lblTieuDeThoiTiet.Text = T("Weather service unavailable", "Không kết nối được dịch vụ thời tiết");
                lblIcon.Text = "📡";
                lblChiTiet.Text = T("Please check your internet connection.", "Vui lòng kiểm tra kết nối mạng.");
                lblTrangThai.Text = T("You can still add and edit trips.", "Bạn vẫn có thể thêm và sửa chuyến đi bình thường.");
                break;

            default:
                lblTieuDeThoiTiet.Text = T("Weather forecast", "Dự báo thời tiết");
                lblIcon.Text = "🌤️";
                lblChiTiet.Text = T("Select a trip, then press \"View weather\".", "Chọn một chuyến đi rồi bấm \"Xem thời tiết\".");
                lblTrangThai.Text = "";
                break;
        }
    }

    private static string BieuTuong(int code) => code switch
    {
        0 => "☀️",
        >= 1 and <= 3 => "⛅",
        45 or 48 => "🌫️",
        (>= 51 and <= 67) or (>= 80 and <= 82) => "🌧️",
        >= 95 and <= 99 => "⛈️",
        (>= 71 and <= 77) or 85 or 86 => "❄️",
        _ => "🌥️"
    };

    private string MoTaThoiTiet(int code) => code switch
    {
        0 => T("Clear sky", "Trời quang"),
        >= 1 and <= 3 => T("Cloudy", "Có mây"),
        45 or 48 => T("Fog", "Sương mù"),
        (>= 51 and <= 67) or (>= 80 and <= 82) => T("Rain", "Mưa"),
        >= 95 and <= 99 => T("Thunderstorm", "Dông"),
        (>= 71 and <= 77) or 85 or 86 => T("Snow", "Tuyết"),
        _ => T("Changeable weather", "Thời tiết thay đổi")
    };

    // ===================== TIỆN ÍCH =====================

    private void ThongBao(string noiDung, MessageBoxIcon icon = MessageBoxIcon.Information) =>
        MessageBox.Show(this, noiDung, T("Notice", "Thông báo"), MessageBoxButtons.OK, icon);

    private void LoiCsdl(Exception ex, string thaoTac)
    {
        Log.Error(ex, "Lỗi CSDL khi {ThaoTac}", thaoTac);
        ThongBao(T("The operation failed. Please check the data and the database connection.",
                   "Thao tác thất bại. Vui lòng kiểm tra dữ liệu và kết nối cơ sở dữ liệu."), MessageBoxIcon.Error);
    }
}
