using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bai2.Services
{
    public class ProvinceItem
    {
        public int code { get; set; }
        public string name { get; set; } = string.Empty;
        public string division_type { get; set; } = string.Empty;
        public string codename { get; set; } = string.Empty;
        public int? phone_code { get; set; }

        public override string ToString() => name;
    }

    public class WardItem
    {
        public int code { get; set; }
        public string name { get; set; } = string.Empty;
        public string division_type { get; set; } = string.Empty;
        public string codename { get; set; } = string.Empty;
        public int? province_code { get; set; }

        public override string ToString() => name;
    }

    public class ProvinceDetailResponse
    {
        public int code { get; set; }
        public string name { get; set; } = string.Empty;
        public List<WardItem>? wards { get; set; }
        public List<WardItem>? districts { get; set; }
    }

    public static class DiaChinhService
    {
        // 1 HttpClient dùng chung toàn ứng dụng, Timeout 10 giây
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<List<ProvinceItem>> GetProvincesAsync(string? baseUrl = null)
        {
            string url = string.IsNullOrWhiteSpace(baseUrl) 
                ? "https://provinces.open-api.vn/api/v2/" 
                : baseUrl;

            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProvinceItem>>(json, _jsonOptions) ?? new List<ProvinceItem>();
        }

        public static async Task<List<WardItem>> GetWardsAsync(int provinceCode, string? baseUrl = null)
        {
            string baseUri = string.IsNullOrWhiteSpace(baseUrl)
                ? "https://provinces.open-api.vn/api/v2/"
                : baseUrl;

            if (!baseUri.EndsWith("/")) baseUri += "/";
            string url = $"{baseUri}p/{provinceCode}?depth=2";

            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var detail = JsonSerializer.Deserialize<ProvinceDetailResponse>(json, _jsonOptions);
            return detail?.wards ?? detail?.districts ?? new List<WardItem>();
        }
    }
}
