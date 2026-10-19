# Bài 5 – Quản lý đặt tour (v1.0.0)

Ứng dụng WinForms (.NET 10, EF Core Database First) quản lý **Tour – Khách hàng – Đặt tour**, tự lấy tỷ giá ngoại tệ → VND từ API (có địa chỉ dự phòng + bộ nhớ đệm 10 phút).

## Cấu trúc project

```
Bai5/
├── QL_DatTour.sql              Script tạo CSDL + dữ liệu mẫu (nộp kèm)
├── appsettings.json            Connection string + mục "ExchangeRate" (không đưa lên Git)
├── appsettings.example.json    File mẫu để chép thành appsettings.json
├── Program.cs                  Khởi tạo cấu hình, Serilog, bắt lỗi toàn cục
├── FormMain.cs / .Designer.cs  Form chính – TabControl 3 tab, phiên bản trên thanh tiêu đề
├── UcTour.cs / .Designer.cs        Tab "Tour": CRUD + tìm theo tên / điểm đến
├── UcKhachHang.cs / .Designer.cs   Tab "Khách hàng": CRUD + tìm theo tên / SĐT
├── UcDatTour.cs / .Designer.cs     Tab "Đặt tour": đặt tour, danh sách JOIN, tìm, tổng doanh thu
├── Helpers/   AppConfig, AppSettings (lớp cấu hình có kiểu), DbContextHelper, LogHelper, ...
├── Models/    Entity scaffold (Tour, KhachHang, DatTour, QL_DatTourContext) + ViewModels
├── Services/TyGiaService.cs    LayTyGiaAsync: địa chỉ chính → dự phòng, cache 10 phút
└── Properties/PublishProfiles/ FrameworkDependent.pubxml, SelfContained.pubxml
```

## Chạy ứng dụng

1. Mở `QL_DatTour.sql` trong SSMS (server `.`) → **Execute** để tạo CSDL `QL_DatTour` với 5 tour, 6 khách, 7 đơn mẫu.
2. Mở `Bai5.slnx` bằng Visual Studio → **Build** → **Run** (F5).
3. Nếu SQL Server của máy là instance khác, sửa `ConnectionStrings:DefaultConnection` trong `appsettings.json`.

> Scaffold lại (nếu cần): chuột phải project → *EF Core Power Tools → Reverse Engineer* (đã có sẵn `efpt.config.json`, dùng tên cột gốc của CSDL). Các lớp hiển thị nằm riêng trong `Models/ViewModels.cs` nên không bị ghi đè.

## Kiểm tra theo "Kết quả mong đợi"

| Kịch bản | Cách làm | Kết quả |
|---|---|---|
| Tỷ giá theo tour | Tab *Đặt tour* → chọn tour Bangkok (THB), rồi Seoul (KRW) | Label hiện tỷ giá THB→VND, rồi đổi sang KRW→VND; tổng = giá × số người × tỷ giá |
| Cache 10 phút | Đổi qua lại giữa các tour | Dòng nguồn ghi "Lấy từ bộ nhớ đệm", log không gọi API lặp lại |
| Địa chỉ dự phòng | Sửa `PrimaryUrl` trong `appsettings.json` thành địa chỉ sai (vd. `https://cdn.jsdelivr.net/npm/sai-ten/{code}.json`), mở lại app | Vẫn lấy được tỷ giá ("nguồn dự phòng"); log có `[WRN] Địa chỉ chính lỗi (...) – chuyển sang địa chỉ dự phòng` và `[INF] ... từ địa chỉ DỰ PHÒNG` |
| Chặn vượt chỗ | Chọn tour, nhập số người > số chỗ còn lại → *Đặt tour* | Hiện thông báo "Không đủ chỗ! ... chỉ còn N chỗ" |
| Giữ tỷ giá cũ | Đặt tour, mai mở lại | Đơn cũ vẫn giữ cột Tỷ giá / Tổng tiền đã lưu |
| Mất mạng | Rút mạng → chọn tour | Báo nhẹ nhàng "Không lấy được tỷ giá...", app không treo |

Log nằm trong thư mục `Logs/log-yyyyMMdd.txt` cạnh file `.exe`.

## Đóng gói (9.1)

Trong Visual Studio: chuột phải project → **Publish** → chọn profile, hoặc chạy lệnh trong thư mục `Bai5`:

```powershell
# Bản Framework-Dependent (máy đích cần .NET 10 Desktop Runtime)
dotnet publish -p:PublishProfile=FrameworkDependent

# Bản Self-Contained + Single File (máy đích KHÔNG cần cài .NET)
dotnet publish -p:PublishProfile=SelfContained
```

Kết quả nằm ở `bin\Release\publish\FrameworkDependent\` và `bin\Release\publish\SelfContained\`. Cả hai thư mục đều có `appsettings.json` nằm cạnh `QuanLyDatTour.exe` → sang máy khác chỉ cần sửa connection string trong file này, không cần build lại.

Đo dung lượng và số file (PowerShell):

```powershell
foreach ($d in "bin\Release\publish\FrameworkDependent","bin\Release\publish\SelfContained") {
  $f = Get-ChildItem $d -Recurse -File
  "{0}: {1} file, {2:N1} MB" -f $d, $f.Count, (($f | Measure-Object Length -Sum).Sum / 1MB)
}
```

### Bảng so sánh (điền số đo thực tế)

| Tiêu chí | Framework-Dependent | Self-Contained (Single File) |
|---|---|---|
| Số file trong thư mục publish | … | … |
| Tổng dung lượng | … MB | … MB |
| Máy đích cần cài .NET? | Có (.NET 10 Desktop Runtime) | Không |
| Ưu điểm | Nhẹ, cập nhật runtime qua Windows Update | Chép là chạy, chỉ 1 file .exe + appsettings.json |
| Nhược điểm | Phải cài runtime trước | Nặng hơn nhiều, mỗi app mang theo runtime riêng |

### Ảnh chụp cần nộp

1. Thư mục publish (Self-Contained) – thấy `QuanLyDatTour.exe` và `appsettings.json`.
2. Thông tin dung lượng (Properties của 2 thư mục hoặc kết quả lệnh PowerShell ở trên).
3. Ứng dụng chạy trên máy thứ hai chưa cài .NET (máy khác / máy ảo / Windows Sandbox), tiêu đề hiện `Quản lý đặt tour - v1.0.0`.
