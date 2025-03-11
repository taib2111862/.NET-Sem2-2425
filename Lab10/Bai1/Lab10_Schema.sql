create database QLSV;
go

use QLSV;
go

create table SinhVien(
	MaSV varchar(8) primary key,
	TenSV nvarchar(50) not null,
	Phai char(1) check(Phai = '0' or Phai = '1') not null, --  0: Nu, 1: Nam
	Lop nvarchar(10)
);
go

insert into SinhVien(MaSV, TenSV, Phai, Lop)
values 
	('B2105688', N'Nguyễn Phương Thuỵ', '0', 'DI21V7F3'),
	('B2111862', N'Phạm Trần Anh Tài', '1', 'DI21V7F4'),
	('B2105721', N'Nguyễn Thái Thuận', '1', 'DI21V7F4'),
	('B2111929', N'Trần Đình Khang', '1', 'DI21V7F4'),
	('B2105665', N'Lâm Nhật Hào', '1', 'DI21V7F4'),
	('B2105704', N'Đinh Hà Khang', '1', 'DI21V7F4'),
	('B2109666', N'Tô Kiều Diễm Quỳnh', '0', 'DI21V7F4'),
	('B2111917', N'Phạm Công Danh', '1', 'DI21V7F4'),
	('B2111951', N'Vũ Trần Quốc Thái', '1', 'DI21V7F3'),
	('B2105686', N'Kim Duy Thành', '1', 'DI21V7F2'),
	('B2105670', N'Dương Minh Khang', '1', 'DI21V7F2'),
	('B2111957', N'Phan Trung Thuận', '1', 'DI21V7F3');
go

select * from SinhVien;
go