CREATE DATABASE QLKhachHang;
USE QLKhachHang;


CREATE TABLE KhachHang (
    TenDN NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(50),
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh BIT,
    Email NVARCHAR(100),
    ThuNhap FLOAT
);

ALTER TABLE KhachHang
ADD CONSTRAINT PK_TenDN PRIMARY KEY (TenDN);

-- R�ng bu?c NOT NULL
ALTER TABLE KhachHang
ALTER COLUMN MatKhau NVARCHAR(50) NOT NULL;

ALTER TABLE KhachHang
ALTER COLUMN HoTen NVARCHAR(100) NOT NULL;

ALTER TABLE KhachHang
ALTER COLUMN NgaySinh DATE NOT NULL;

ALTER TABLE KhachHang
ALTER COLUMN Email NVARCHAR(100) NOT NULL;

ALTER TABLE KhachHang
ALTER COLUMN ThuNhap FLOAT NOT NULL;

-- R�ng bu?c CHECK
ALTER TABLE KhachHang
ADD CONSTRAINT CHK_GioiTinh CHECK (GioiTinh IN (0, 1));

-- R�ng bu?c UNIQUE
ALTER TABLE KhachHang
ADD CONSTRAINT UQ_Email UNIQUE (Email);

-- R�ng bu?c DEFAULT
ALTER TABLE KhachHang
ADD CONSTRAINT DF_NgaySinh DEFAULT GETDATE() FOR NgaySinh;

ALTER TABLE KhachHang
ADD CONSTRAINT chk_Email CHECK (Email LIKE '%_@__%.__%');

ALTER TABLE KhachHang
ADD CONSTRAINT chk_ThuNhap CHECK (ThuNhap BETWEEN 1000000 AND 50000000);

-- Th�m d? li?u v�o b?ng
INSERT INTO KhachHang (TenDN, MatKhau, HoTen, NgaySinh, GioiTinh, Email, ThuNhap) VALUES
('user01', 'Pass@123', N'Nguy?n Van A', '1990-05-15', '1', 'nguyenvana01@example.com', 5000000),
('user02', 'Pass@123', N'Tr?n Th? B', '1985-07-20', '0', 'tranthib02@example.com', 8000000),
('user03', 'Pass@123', N'Ph?m Van C', '1992-09-10', '1', 'phamvanc03@example.com', 12000000),
('user04', 'Pass@123', N'L� Th? D', '1998-12-25', '0', 'lethid04@example.com', 10000000),
('user05', 'Pass@123', N'Ho�ng Van E', '1987-03-05', '1', 'hoangvane05@example.com', 25000000),
('user06', 'Pass@123', N'�?ng Th? F', '1995-06-18', '0', 'dangthif06@example.com', 15000000),
('user07', 'Pass@123', N'B�i Van G', '1991-08-22', '1', 'buivang07@example.com', 30000000),
('user08', 'Pass@123', N'V� Th? H', '1993-11-30', '0', 'vothih08@example.com', 4000000),
('user09', 'Pass@123', N'Ng� Van I', '1989-04-14', '1', 'ngovanii09@example.com', 18000000),
('user10', 'Pass@123', N'Duong Th? J', '1997-10-08', '0', 'duongthij10@example.com', 22000000),
('user11', 'Pass@123', N'Nguyễn Văn K', '1990-10-12', '1', 'nguyenvank@example.com', 5000000),
('user12', 'Pass@123', N'Nguyễn Thị L', '1995-06-12', '0', 'nguyenthil@example.com', 6000000);
