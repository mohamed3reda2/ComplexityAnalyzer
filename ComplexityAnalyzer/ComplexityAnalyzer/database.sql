
CREATE DATABASE ComplexityAnalyzerDB;
GO


USE ComplexityAnalyzerDB;
GO


CREATE TABLE UserSubmissions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,    
    Email NVARCHAR(100) NOT NULL,   
        Code1 NVARCHAR(MAX),
    Code2 NVARCHAR(MAX),
    Code3 NVARCHAR(MAX),
    Code4 NVARCHAR(MAX),
    Code5 NVARCHAR(MAX),
	starttime DATETIMe ,
    SubmissionDate DATETIME ,
	totaltime AS DATEDIFF(MINUTE, starttime, SubmissionDate)
);
GO
create table users(
 Id INT IDENTITY(1,1) PRIMARY KEY, 
     Name NVARCHAR(100) NOT NULL,     
    Email NVARCHAR(100) NOT NULL,
	datelog datetime
)
select * from UserSubmissions
select * from users