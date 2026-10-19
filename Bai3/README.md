# Bài 3 - Kế hoạch dã ngoại

Ứng dụng WinForms quản lý chuyến đi, lọc danh sách và xem dự báo Open-Meteo theo địa điểm/ngày đi. Giao diện hỗ trợ tiếng Việt và English; lựa chọn ngôn ngữ được lưu trong `%LocalAppData%\KeHoachDaNgoai\usersettings.json`.

## Chạy ứng dụng

1. Mở `QL_DaNgoai.sql` bằng SQL Server Management Studio và chạy script để tạo CSDL `QL_DaNgoai` cùng 8 chuyến mẫu.
2. Mặc định kết nối `Server=.` (SQL Server cài trên máy, giống Bài 1, Bài 2). Nếu máy dùng instance khác (ví dụ `.\SQLEXPRESS` hoặc `(localdb)\MSSQLLocalDB`), đổi `ConnectionStrings:DefaultConnection` trong `appsettings.json` hoặc đặt biến môi trường `DB_CONNECTION_STRING`.
3. Mở `Bai3.slnx` trong Visual Studio hoặc chạy `dotnet run --project Bai3.csproj` trên Windows có .NET 10 Desktop Runtime.

API thời tiết cần kết nối Internet. Khi không tìm thấy địa điểm hoặc API không truy cập được, người dùng vẫn có thể nhập và lưu chuyến đi.

## Publish

Trong Visual Studio chọn profile `FolderProfile` để publish Framework-Dependent `win-x64` vào `bin/Release/publish`. Thư mục publish phải đi kèm `appsettings.json`; máy đích cần cài .NET 10 Desktop Runtime và có thể truy cập SQL Server được khai báo trong connection string.
