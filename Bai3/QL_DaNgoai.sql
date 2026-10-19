-- =============================================
-- CSDL: QL_DaNgoai
-- Bài tập 3: Kế hoạch dã ngoại (Chương 11)
-- =============================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QL_DaNgoai')
BEGIN
    CREATE DATABASE QL_DaNgoai;
END
GO

USE QL_DaNgoai;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'ChuyenDi')
BEGIN
    CREATE TABLE ChuyenDi (
        MaChuyen INT IDENTITY(1,1) PRIMARY KEY,
        TenChuyen NVARCHAR(100) NOT NULL,
        DiaDiem NVARCHAR(100) NOT NULL,
        NgayDi DATE NOT NULL,
        SoNguoi INT NOT NULL,
        NganSach DECIMAL(18, 0) NOT NULL,
        PhuongTien NVARCHAR(30) NOT NULL,
        DaHoanThanh BIT NOT NULL DEFAULT 0,
        GhiChu NVARCHAR(200) NULL
    );
END
GO

-- Xóa dữ liệu cũ nếu có và nạp 8 chuyến mẫu
TRUNCATE TABLE ChuyenDi;
GO

INSERT INTO ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
(N'Khám phá phố cổ & ẩm thực', N'Hội An', '2026-10-22', 4, 5000000, N'Xe khách', 0, N'Check-in phố đèn lồng & thả hoa đăng'),
(N'Cắm trại đồi chè săn mây', N'Đà Lạt', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Mang theo áo ấm, lều trại và đồ nướng'),
(N'Nghỉ dưỡng biển cuối tuần', N'Vũng Tàu', '2026-10-27', 5, 4000000, N'Xe máy', 0, N'Tắm biển Bãi Sau, ăn hải sản'),
(N'Chinh phục đỉnh Fansipan', N'Sa Pa', '2026-10-30', 4, 6500000, N'Tàu hỏa', 0, N'Đi cáp treo, ngắm ruộng bậc thang'),
(N'Khám phá quần thể Tràng An', N'Ninh Bình', '2026-11-02', 8, 4800000, N'Xe khách', 0, N'Chèo thuyền hang động, thăm chùa Bái Đính'),
(N'Phượt đèo ngắm bình minh', N'Đà Nẵng', '2026-11-04', 4, 5500000, N'Xe máy', 0, N'Chinh phục đèo Hải Vân và cầu Rồng'),
(N'Kỳ nghỉ dài ngày đảo ngọc', N'Phú Quốc', '2026-11-15', 2, 12000000, N'Ô tô', 0, N'Chuyến đi sau 16 ngày để test vượt khung dự báo'),
(N'Dã ngoại công viên cắm trại', N'Hà Nội', '2026-10-12', 10, 2000000, N'Xe máy', 1, N'Chuyến đi đã hoàn thành tuần trước');
GO

SELECT 
    MaChuyen, 
    TenChuyen, 
    DiaDiem, 
    CONVERT(VARCHAR(10), NgayDi, 103) AS NgayDi, 
    SoNguoi, 
    NganSach, 
    PhuongTien, 
    DaHoanThanh, 
    GhiChu 
FROM ChuyenDi;
GO
