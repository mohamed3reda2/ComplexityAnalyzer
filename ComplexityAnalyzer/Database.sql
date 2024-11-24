-- إنشاء قاعدة البيانات
CREATE DATABASE ComplexityAnalyzerDB;
GO

-- استخدام قاعدة البيانات
USE ComplexityAnalyzerDB;
GO

-- إنشاء جدول لتخزين البيانات
CREATE TABLE UserSubmissions (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- رقم تسلسلي
    Name NVARCHAR(100) NOT NULL,     -- اسم المستخدم
    Email NVARCHAR(100) NOT NULL,    -- البريد الإلكتروني
        Code1 NVARCHAR(MAX),
    Code2 NVARCHAR(MAX),
    Code3 NVARCHAR(MAX),
    Code4 NVARCHAR(MAX),
    Code5 NVARCHAR(MAX),
	starttime DATETIMe ,
    SubmissionDate DATETIME , -- تاريخ الحفظ
	totaltime AS DATEDIFF(MINUTE, starttime, SubmissionDate)
);
GO
create table users(
 Id INT IDENTITY(1,1) PRIMARY KEY, 
     Name NVARCHAR(100) NOT NULL,     -- اسم المستخدم
    Email NVARCHAR(100) NOT NULL,
	datelog datetime
)
select * from UserSubmissions
select * from users