use master
Drop Database CuaHang
create database CuaHang
go
use CuaHang
go

create table Account(
	Username varchar(50) primary key,
	[Password] char(20) 
)
go

create table Category(
	ID int identity(1000,1) primary key,
	[Name] nvarchar(100) not null,
	[Image] ntext,
	IsDeleted bit default 0
)
go

create table Brand(
	ID int identity(1000,1) primary key,
	[Name] nvarchar(100) not null,
	[Image] ntext,
	IsDeleted bit default 0
)
go

create table Product(
	ID int identity(1000,1) primary key,
	[Name] nvarchar(100) not null,
	Cost int not null,
	[Desceiption] ntext,
	Details ntext,
	[Image] ntext,
	IsSeller bit default 0,
	OnTop bit default 0,
	IDCategory int not null constraint fk_1 foreign key(IDCategory) references Category(ID),
	IDBrand int not null constraint fk_2 foreign key(IDBrand) references Brand(ID),
	IsDeleted bit default 0
)
go

create table DonDatHang(
	MaDonHang int identity(1000,1) primary key,
	DaThanhToan bit default 0,
	Tinhtranggiaohang bit default 0,
	Ngaydat datetime,
	Ngaygiao datetime,
	MaKhachHang int not null constraint fk_4 foreign Key(MaKhachHang) references KhanhHang(MaKH),

)
go

create table KhanhHang(
	MaKH int identity(1000,1) primary key,
	[HoTen] nvarchar(100) not null,
	[TaiKhoan] varchar(100) not null,
	[MatKhau] varchar(50) not null,
	[Email] varchar(100) not null,
	[DiaChiKH] nvarchar(100) not null,
	[DienthoaiKH] varchar(20) not null,
	Ngaysinh datetime,
	IsDeleted bit default 0
	)
go

create table ChiTietDonHang(
	MaDonHang int identity(1000,1) primary key constraint fk_5 foreign key(MaDonHang) references DonDatHang(MaDonHang) ,
	MaSP int primary key primary key constraint fk_6 foreign key(MaSP) references Product(ID),
	Soluong int,
	Dongia decimal(18,0) check (Dongia>0),
	IsDelet bit default 0

)
go

create table ImageProduct(
	ID int identity(1000,1) primary key,
	[Image] ntext,
	IDProduct int not null  constraint fk_3 foreign key(IDProduct) references Product(ID)
)
go

create table Slider(
	ID int identity(1,1000) primary key,
	[Image] ntext,
	IsShow bit default 0
)
go







