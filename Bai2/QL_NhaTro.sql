USE master;
GO
IF DB_ID(N'QL_NhaTro') IS NULL CREATE DATABASE QL_NhaTro;
GO
USE QL_NhaTro;
GO
IF OBJECT_ID(N'dbo.PhongTro', N'U') IS NULL
CREATE TABLE dbo.PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL CHECK (GiaThue >= 0),
    TinhTrang NVARCHAR(20) NOT NULL DEFAULT N'Trống'
);
IF OBJECT_ID(N'dbo.KhachThue', N'U') IS NULL
CREATE TABLE dbo.KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NOT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL DEFAULT N'',
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL,
    CONSTRAINT FK_KhachThue_PhongTro FOREIGN KEY (MaPhong) REFERENCES dbo.PhongTro(MaPhong)
);
GO
IF NOT EXISTS (SELECT 1 FROM dbo.PhongTro)
BEGIN
    INSERT INTO dbo.PhongTro(TenPhong, GiaThue, TinhTrang) VALUES
    (N'P01',1500000,N'Đang thuê'),(N'P02',1600000,N'Đang thuê'),(N'P03',1800000,N'Đang thuê'),
    (N'P04',2000000,N'Trống'),(N'P05',1700000,N'Trống'),(N'P06',2200000,N'Trống');
    INSERT INTO dbo.KhachThue(HoTen,GioiTinh,NgaySinh,SoDienThoai,MaTinh,TenTinh,MaPhuongXa,TenPhuongXa,DaDangKyTamTru,MaPhong)
    VALUES (N'Nguyễn Văn An',N'Nam','2004-05-12','0912345678',1,N'Thành phố Hà Nội',1,N'Phường Ba Đình',1,1),
    (N'Trần Thị Bình',N'Nữ','2003-09-23','0876543210',25,N'Tỉnh Nam Định',NULL,N'',0,2),
    (N'Lê Văn Cường',N'Nam','2002-02-14','0901234567',38,N'Tỉnh Thanh Hóa',NULL,N'',0,3);
END
GO
