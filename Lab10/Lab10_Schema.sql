use SINH_VIEN;
go

create table SinhVien(
	MaSV varchar(8) primary key,
	TenSV nvarchar(50) not null,
	Phai char(1) check(Phai = '0' or Phai = '1') not null, -- 1: Nam, 2: Nu
	Lop nvarchar(10)
);
go

insert into SINH_VIEN(MaSV, TenSV, Phai, Lop)
values 
	('B2105688', 'Nguyễn Phương Thuỵ', '2', 'DI21V7F3'),
	('B2111862', 'Phạm Trần Anh Tài', '1', 'DI21V7F4'),
	('B2105721', 'Nguyễn Thái Thuận', '1', 'DI21V7F4'),
	('B2111929', 'Trần Đình Khang', '1', 'DI21V7F4'),
	('B2105665', 'Lâm Nhật Hào', '1', 'DI21V7F4'),
	('B2105704', 'Đinh Hà Khang', '1', 'DI21V7F4'),
	('B2109666', 'Tô Kiều Diễm Quỳnh', '2', 'DI21V7F4'),
	('B2111917', 'Phạm Công Danh', '1', 'DI21V7F4');
go