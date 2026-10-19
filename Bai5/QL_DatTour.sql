-- =============================================
-- CSDL: QL_DatTour
-- Bài tập 5: Quản lý đặt tour (Chương 11)
-- Bảng: Tour, KhachHang, DatTour (khóa ngoại MaKH, MaTour)
-- Chạy lại nhiều lần được: xóa bảng cũ rồi tạo lại + nạp dữ liệu mẫu
-- =============================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_DatTour')
BEGIN
    CREATE DATABASE QL_DatTour;
END
GO

USE QL_DatTour;
GO

-- Xóa theo thứ tự: bảng con trước, bảng cha sau
IF OBJECT_ID(N'dbo.DatTour', N'U') IS NOT NULL DROP TABLE dbo.DatTour;
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID(N'dbo.Tour', N'U') IS NOT NULL DROP TABLE dbo.Tour;
GO

-- ===================== BẢNG TOUR =====================
CREATE TABLE dbo.Tour (
    MaTour        INT IDENTITY(1,1) NOT NULL,
    TenTour       NVARCHAR(100)     NOT NULL,
    DiemDen       NVARCHAR(50)      NOT NULL,
    NgoaiTe       CHAR(3)           NOT NULL,
    GiaNgoaiTe    DECIMAL(18, 2)    NOT NULL,
    NgayKhoiHanh  DATE              NOT NULL,
    SoChoToiDa    INT               NOT NULL,
    CONSTRAINT PK_Tour PRIMARY KEY (MaTour),
    CONSTRAINT CK_Tour_NgoaiTe    CHECK (NgoaiTe IN ('THB', 'KRW', 'JPY', 'USD')),
    CONSTRAINT CK_Tour_GiaNgoaiTe CHECK (GiaNgoaiTe > 0),
    CONSTRAINT CK_Tour_SoChoToiDa CHECK (SoChoToiDa > 0)
);
GO

-- ===================== BẢNG KHÁCH HÀNG =====================
CREATE TABLE dbo.KhachHang (
    MaKH         INT IDENTITY(1,1) NOT NULL,
    HoTen        NVARCHAR(100)     NOT NULL,
    SoDienThoai  VARCHAR(15)       NOT NULL,
    Email        NVARCHAR(100)     NULL,
    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH)
);
GO

-- ===================== BẢNG ĐẶT TOUR =====================
CREATE TABLE dbo.DatTour (
    MaDat        INT IDENTITY(1,1) NOT NULL,
    MaKH         INT               NOT NULL,
    MaTour       INT               NOT NULL,
    SoNguoi      INT               NOT NULL,
    NgayDat      DATETIME          NOT NULL CONSTRAINT DF_DatTour_NgayDat DEFAULT (GETDATE()),
    TyGia        DECIMAL(18, 4)    NOT NULL,   -- tỷ giá tại thời điểm đặt (không đổi về sau)
    TongTienVND  DECIMAL(18, 0)    NOT NULL,   -- = GiaNgoaiTe * SoNguoi * TyGia
    CONSTRAINT PK_DatTour PRIMARY KEY (MaDat),
    CONSTRAINT FK_DatTour_KhachHang FOREIGN KEY (MaKH)   REFERENCES dbo.KhachHang (MaKH),
    CONSTRAINT FK_DatTour_Tour      FOREIGN KEY (MaTour) REFERENCES dbo.Tour (MaTour),
    CONSTRAINT CK_DatTour_SoNguoi   CHECK (SoNguoi > 0),
    CONSTRAINT CK_DatTour_TyGia     CHECK (TyGia > 0)
);
GO

-- ===================== DỮ LIỆU MẪU =====================
INSERT INTO dbo.Tour (TenTour, DiemDen, NgoaiTe, GiaNgoaiTe, NgayKhoiHanh, SoChoToiDa) VALUES
(N'Bangkok – Pattaya 5N4Đ',                N'Thái Lan',  'THB',    8900.00, '2026-11-20', 25),
(N'Seoul – Nami – Everland 5N4Đ',          N'Hàn Quốc',  'KRW', 1250000.00, '2026-12-05', 20),
(N'Tokyo – Phú Sĩ 6N5Đ',                   N'Nhật Bản',  'JPY',  165000.00, '2026-12-18', 18),
(N'Osaka – Kyoto mùa hoa anh đào 5N4Đ',    N'Nhật Bản',  'JPY',  148000.00, '2027-03-28', 20),
(N'Bờ Tây nước Mỹ: Los Angeles – Las Vegas 8N7Đ', N'Hoa Kỳ', 'USD', 1890.00, '2027-01-10', 15);
GO

INSERT INTO dbo.KhachHang (HoTen, SoDienThoai, Email) VALUES
(N'Nguyễn Văn An',     '0901234567', N'an.nguyen@example.com'),
(N'Trần Thị Bích',     '0912345678', N'bich.tran@example.com'),
(N'Lê Hoàng Cường',    '0923456789', N'cuong.le@example.com'),
(N'Phạm Thị Dung',     '0934567890', N'dung.pham@example.com'),
(N'Hoàng Minh Đức',    '0945678901', N'duc.hoang@example.com'),
(N'Võ Thị Hồng Nhung', '0956789012', NULL);
GO

-- Tỷ giá mẫu (giả định) lưu tại thời điểm đặt; TongTienVND = GiaNgoaiTe * SoNguoi * TyGia
INSERT INTO dbo.DatTour (MaKH, MaTour, SoNguoi, NgayDat, TyGia, TongTienVND) VALUES
(1, 1, 2, '2026-10-10 09:15:00',   752.3500,  13391830),
(2, 1, 4, '2026-10-12 14:30:00',   752.3500,  26783660),
(3, 2, 2, '2026-10-13 10:05:00',    18.4521,  46130250),
(4, 3, 3, '2026-10-15 16:45:00',   170.8350,  84563325),
(5, 5, 1, '2026-10-16 08:20:00', 26315.0000,  49735350),
(6, 2, 5, '2026-10-17 19:10:00',    18.4521, 115325625),
(2, 4, 2, '2026-10-18 11:00:00',   170.8350,  50567160);
GO

-- ===================== KIỂM TRA =====================
SELECT * FROM dbo.Tour;
SELECT * FROM dbo.KhachHang;

-- Danh sách đặt tour (JOIN) + số chỗ còn lại của từng tour
SELECT d.MaDat, k.HoTen, t.TenTour, d.SoNguoi, d.TyGia, d.TongTienVND,
       CONVERT(VARCHAR(16), d.NgayDat, 120) AS NgayDat
FROM dbo.DatTour d
JOIN dbo.KhachHang k ON k.MaKH = d.MaKH
JOIN dbo.Tour t      ON t.MaTour = d.MaTour
ORDER BY d.NgayDat;

SELECT t.MaTour, t.TenTour, t.SoChoToiDa,
       ISNULL(SUM(d.SoNguoi), 0)                AS DaDat,
       t.SoChoToiDa - ISNULL(SUM(d.SoNguoi), 0) AS ConLai
FROM dbo.Tour t
LEFT JOIN dbo.DatTour d ON d.MaTour = t.MaTour
GROUP BY t.MaTour, t.TenTour, t.SoChoToiDa;
GO
