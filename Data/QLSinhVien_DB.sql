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

go
create table Student
(
	StudentID int primary key,
	StudentName Nvarchar(100),
	Birthday date,
	Gender nchar(3) constraint Ck_s_Gd check(Gender in (N'Nam' , N'Nữ')),
	Address nvarchar(100),
	ClassID int
)
go

create table Class
(
	ClassID int primary key,
	DepartmentID varchar(10) foreign key references Department(DepartmentID) on delete cascade,
	ClassName Nvarchar(50)

)
go

create table Department
(
	DepartmentID varchar(10) primary key,
	DepartmentName Nvarchar(50)
)
go
create table Teacher
(
	TeacherID int primary key,
	TeacherName Nvarchar(50),
	Gender nchar(3) constraint Ck_T_Gd check(Gender in (N'Nam' , N'Nữ')),
	Phone varchar(10),
	Email varchar(50) constraint ck_tc_E check(Email like '%@%'),
	TeacherType nvarchar(50)
)
go

create table Subject
(
	SubjectID varchar(10) primary key,
	SubjectName Nvarchar(100),
	TeacherID int foreign key references Teacher(TeacherID) on delete cascade,
	Semester bit,
	DepartmentID varchar(10) foreign key references Department(DepartmentID) on delete cascade
)
go

create table Result
(
	StudentID int foreign key references Student(StudentID) on delete cascade,
	StudentName Nvarchar(100) ,
	ClassID int ,
	SubjectID varchar(10) 

	constraint pk_st_cl_sj primary key(StudentID, SubjectID)
)
alter table Result add constraint FK_Rs_sj foreign key (SubjectID) references Subject(SubjectID)
go












--PROCEDURE
create proc USP_Login 
@userName varchar(50) , @passWord varchar(50) , @accountType bit
as
begin
	select * from Account where UserName = @userName and PassWord = @passWord and AccountType = @accountType
end
go

exec USP_Login @userName = 'hoafn3007',  @passWord = '1' , @accountType = 1
go

--
create proc USP_CreateAccount
@userName varchar(50) , @displayName Nvarchar(100) , @passWord varchar(50) , @accountType bit
as
begin	
	insert Account values(@userName, @displayName, @passWord, @accountType)
end
go
