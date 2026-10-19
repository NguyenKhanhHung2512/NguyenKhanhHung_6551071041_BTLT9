USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_ChiTieu')
BEGIN
    CREATE DATABASE QL_ChiTieu;
END
GO

USE QL_ChiTieu;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'ChiTieu')
BEGIN
    CREATE TABLE ChiTieu (
        MaCT INT IDENTITY(1,1) PRIMARY KEY,
        NgayChi DATE NOT NULL DEFAULT (CONVERT(DATE, GETDATE())),
        NoiDung NVARCHAR(100) NOT NULL,
        LoaiChi NVARCHAR(30) NOT NULL,
        SoTien DECIMAL(18, 0) NOT NULL,
        GhiChu NVARCHAR(200) NULL
    );
END
GO

-- Xoa va tao 10 ban ghi mau
TRUNCATE TABLE ChiTieu;
GO

INSERT INTO ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu) VALUES
('2026-10-01', N'Ăn sáng phở bò & cafe', N'Ăn uống', 65000, N'Quán gần nhà'),
('2026-10-02', N'Đổ xăng xe máy', N'Đi lại', 90000, N'Xăng RON 95'),
('2026-10-05', N'Mua giáo trình & tài liệu học kỳ', N'Học tập', 220000, N'Nhà sách sinh viên'),
('2026-10-07', N'Cơm trưa căn tin', N'Ăn uống', 40000, NULL),
('2026-10-10', N'Xem phim rạp cuối tuần', N'Giải trí', 135000, N'Vé phim và bắp nước'),
('2026-10-12', N'Nạp thẻ điện thoại 4G', N'Khác', 100000, N'Gói cước tháng'),
('2026-10-14', N'Thay nhớt & bảo dưỡng xe máy', N'Đi lại', 150000, N'Bảo dưỡng định kỳ 3000km'),
('2026-10-15', N'Gia hạn tài khoản học online', N'Học tập', 300000, N'Khóa học lập trình'),
('2026-10-17', N'Mua đồ dùng sinh hoạt cá nhân', N'Khác', 185000, N'Dầu gội, kem đánh răng tại siêu thị'),
('2026-10-18', N'Uống trà sữa tụ tập bạn bè', N'Giải trí', 60000, NULL);
GO

SELECT * FROM ChiTieu;
GO
