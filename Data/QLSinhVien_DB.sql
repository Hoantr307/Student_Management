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

select * from Account


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

alter table Student 
add constraint FK_S_ClassID foreign key (ClassID) references Class(ClassID) on delete cascade on update cascade


create table Class
(
	ClassID int primary key,
	ClassName Nvarchar(50)
)
go

create table Teacher
(
	TeacherID int primary key,
	TeacherName Nvarchar(50),
	Gender nchar(3) constraint Ck_T_Gd check(Gender in (N'Nam' , N'Nữ')),
	Phone varchar(20),
	Email varchar(50) constraint ck_tc_E check(Email like '%@%'),
	TeacherType nvarchar(50)
)
go
create table Subject
(
	SubjectID varchar(10) primary key,
	SubjectName Nvarchar(100),
	LessonNumber int,
	TeacherID int foreign key references Teacher(TeacherID) on delete cascade on update cascade,
	Semester int
)
go
drop table Result
create table Result
(
	StudentID int foreign key references Student(StudentID) on delete cascade on update cascade,
	StudentName Nvarchar(100) ,
	ClassID int ,
	SubjectID varchar(10),
	ScoreAvg float,
	ScoreElement float,
	ScorePractice float,
	ScoreFinal float,
	Conduct nvarchar(50),
	Description Nvarchar(100)

	constraint pk_st_cl_sj primary key(StudentID, SubjectID)
)
alter table Result add constraint FK_Rs_Subject foreign key (SubjectID) references Subject(SubjectID) on delete cascade on update cascade
go
alter table Result add constraint FK_Rs_Class foreign key (ClassID) references Class(ClassID) 
go


insert Student(StudentID, StudentName, Birthday, Gender, Address, ClassID)
values
('10121587', N'Trần Thế Anh', '2003-01-01', N'Nam', N'Hưng Yên', '125213'),
('10121965', N'Trần Đình Hoàn', '2003-07-30', N'Nam', N'Hưng Yên', '125213'),
('12521168', N'Trần Văn Nam', '2003-10-26', N'Nam', N'Hưng Yên', '125213'),
('12521038', N'Trần Bá Minh Quân', '2003-01-31', N'Nam', N'Hưng Yên', '125213'),
('12521012', N'Đặng Quang Chiến', '2003-11-25', N'Nam', N'Hưng Yên', '125213'),
('10121900', N'Trần Văn Quân', '2003-11-07', N'Nam', N'Hưng Yên', '125213'),
('10121971', N'Nguyễn Thị Ngọc Anh', '2003-01-31', N'Nam', N'Hưng Yên', '125213'),
('10121853', N'Phùng Huy Khải', '2003-05-10', N'Nam', N'Hưng Yên', '125213'),
('10121616', N'Nguyễn Văn Bình', '2003-01-31', N'Nam', N'Hưng Yên', '125213')
go

insert Class
values
('125211', N'sek19.1'),
('125212', N'sek19.2'),
('125213', N'sek19.3'),
('101213', N'itk19.3'),
('101211', N'sek19.1')

insert Teacher(TeacherID, TeacherName, Gender, Phone, Email, TeacherType)
values
('1', N'Nguyễn Hữu Đông', N'Nam', '0983539745', 'dongnguyen123@gmail.com', N'Giảng Viên'),
('2', N'Trịnh Thị Nhị', N'Nữ', '0978606526', 'nhithitrinh4953@gmail.com', N'Giảng Viên'),
('3', N'Ngô Thanh Huyền', N'Nữ', '0982713518', 'Huyenngo123@gmail.com', N'Thạc sĩ'),
('4', N'Đỗ Văn Hùng', N'Nam', '0986472793', 'hungdo@gmail.com', N'Giảng Viên'),
('5', N'Nguyễn Văn Quyết', N'Nam', '0912188636', 'nguyenvanquyet@gmail.com', N'Tiến Sĩ'),
('6', N'Vũ Thị Thùy', N'Nữ', '0934271086', 'thuyvu@gmail.com', N'Giảng Viên'),
('7', N'Trần Mai Duyên', N'Nữ', '0973173179', 'duyentran@gmail.com', N'Giảng Viên'),
('8', N'Nguyễn Đình Chiến', N'Nam', '0962836394', 'chienthan@gmail.com', N'Tiến Sĩ'),
('9', N'Nguyễn Vinh Quy', N'Nam', '0912206765', 'quyan@gmail.com', N'Thạc Sĩ')

insert Subject (SubjectID, SubjectName, LessonNumber, TeacherID, Semester)
values
('LTHDT',N'Lập Trình Hướng Đối Tượng', 45, '1', 1),
('CSDL',N'Cơ Sở Dữ Liệu', 45, '2', 1),
('PTTKTT',N'Phân Tích Thiết Kế Thuận Toán', 30, '3', 1),
('GDTC',N'Giáo Dục Thể Chất', 30, '4', 1),
('LTWF',N'Lập Trình Winform', 45, '5', 1),
('KTCT',N'Kinh Tế Chính Trị', 30, '6', 1),
('TLHKS',N'Tâm Lý Học Kỹ Sư', 30, '7', 1),
('LTCB',N'Lập Trình Cơ Bản Python', 45, '8', 1),
('KTMT',N'Kiến Trúc Máy Tính', 45, '9', 1)





go









--PROCEDURE
create proc USP_Login 
@userName varchar(50) , @passWord varchar(50) , @accountType bit
as
begin
	select * from Account where UserName = @userName and PassWord = @passWord and AccountType = @accountType
end
go


--
create proc USP_CreateAccount
@userName varchar(50) , @displayName Nvarchar(100) , @passWord varchar(50) , @accountType bit
as
begin	
	insert Account values(@userName, @displayName, @passWord, @accountType)
end
go


create proc GetResult
as
begin 
	select StudentID, StudentName, ClassID, SubjectID, ScoreAvg, ScoreElement, ScorePractice, ScoreFinal, Conduct, Description from Result
end
go
