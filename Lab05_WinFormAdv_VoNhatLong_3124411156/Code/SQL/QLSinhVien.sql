/* =====================================================================
   Tạo cơ sở dữ liệu QLSinhVien (SQL Server 2012 trở lên) + dữ liệu mẫu
   Chạy toàn bộ script này trong SQL Server Management Studio (F5).
   ===================================================================== */
USE master;
GO
IF DB_ID('QLSinhVien') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVien;
END
GO
CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO

-- ===== Các bảng =====
CREATE TABLE Khoa (
    MaKhoa  NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

CREATE TABLE Lop (
    MaLop   NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenLop  NVARCHAR(100) NOT NULL,
    MaKhoa  NVARCHAR(10)  NOT NULL REFERENCES Khoa(MaKhoa)
);

CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(10)  NOT NULL PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    NgaySinh   DATE          NOT NULL,
    MaLop      NVARCHAR(10)  NOT NULL REFERENCES Lop(MaLop)
);

CREATE TABLE MonHoc (
    MaMonHoc  NVARCHAR(10)  NOT NULL PRIMARY KEY,
    TenMonHoc NVARCHAR(100) NOT NULL
);

CREATE TABLE Diem (
    MaSinhVien NVARCHAR(10) NOT NULL REFERENCES SinhVien(MaSinhVien),
    MaMonHoc   NVARCHAR(10) NOT NULL REFERENCES MonHoc(MaMonHoc),
    Diem       FLOAT        NOT NULL CHECK (Diem BETWEEN 0 AND 10),
    PRIMARY KEY (MaSinhVien, MaMonHoc)
);
GO

-- ===== Dữ liệu mẫu (mỗi bảng ít nhất 5 mẫu tin) =====
INSERT INTO Khoa VALUES
 (N'CNTT', N'Công nghệ thông tin'),
 (N'CNSH', N'Công nghệ sinh học'),
 (N'CNTP', N'Công nghệ thực phẩm'),
 (N'QTKD', N'Quản trị kinh doanh'),
 (N'KT',   N'Kế toán');

INSERT INTO Lop VALUES
 (N'DHTH1', N'Đại học Tin học 1', N'CNTT'),
 (N'DHTH2', N'Đại học Tin học 2', N'CNTT'),
 (N'DHSH1', N'Đại học Sinh học 1', N'CNSH'),
 (N'DHTP1', N'Đại học Thực phẩm 1', N'CNTP'),
 (N'DHKT1', N'Đại học Kế toán 1', N'KT');

INSERT INTO SinhVien VALUES
 (N'SV001', N'Nguyễn Văn An',   '20030115', N'DHTH1'),
 (N'SV002', N'Trần Thị Bình',   '20030322', N'DHTH1'),
 (N'SV003', N'Lê Quang Cường',  '20020709', N'DHTH2'),
 (N'SV004', N'Phạm Ngọc Dung',  '20030930', N'DHSH1'),
 (N'SV005', N'Hồ Thanh Em',     '20021111', N'DHKT1');

INSERT INTO MonHoc VALUES
 (N'MH01', N'Lập trình .NET'),
 (N'MH02', N'Cơ sở dữ liệu'),
 (N'MH03', N'Cấu trúc dữ liệu'),
 (N'MH04', N'Mạng máy tính'),
 (N'MH05', N'Toán rời rạc');

INSERT INTO Diem VALUES
 (N'SV001', N'MH01', 8.5), (N'SV001', N'MH02', 7.0),
 (N'SV002', N'MH01', 9.0), (N'SV003', N'MH03', 6.5),
 (N'SV004', N'MH02', 7.5), (N'SV005', N'MH05', 8.0);
GO
