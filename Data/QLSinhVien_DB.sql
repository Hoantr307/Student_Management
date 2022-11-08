create database QLSinhVien
go
use QLSinhVien
go

create table Account
(
	UserName varchar(50) primary key,
	DisplayName Nvarchar(100) not null,
	PassWord varchar(50) not null,
	AccountType bit -- 0 : giao vien , 1: sinh vien
)

insert Account
values('hoafn3007', N'Hoàn', '1', 1)

select * from Account 
where UserName = 'hoafn3007'and PassWord = '1' and AccountType = 0


