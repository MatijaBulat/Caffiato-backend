DROP DATABASE CaffiatoDB
GO

CREATE DATABASE CaffiatoDB
GO

USE CaffiatoDB
GO

--Drop tables
DROP TABLE dbo.Deal;
DROP TABLE dbo.[Address];
DROP TABLE dbo.Transact;
DROP TABLE dbo.Caffe;
DROP TABLE dbo.UserCaffe;

DROP TABLE dbo.Feedback;
DROP TABLE dbo.Challenge;


--Create tables
CREATE TABLE dbo.UserCaffe(
	ID int IDENTITY(1,1) NOT NULL,
	Email nvarchar(1024) NOT NULL,
	Username nvarchar(1024),
	FirstName nvarchar(1024) NOT NULL,
	LastName nvarchar(1024),
	DateOfBirth dateTime,
	Oib varchar(11),
	Points int NOT NULL DEFAULT 0,
	CONSTRAINT PK_UserCaffe PRIMARY KEY CLUSTERED(ID)
);
GO

CREATE TABLE dbo.Caffe(
	ID int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(1024) NOT NULL,
	UserCaffeID int NOT NULL,
	CONSTRAINT PK_Caffe PRIMARY KEY CLUSTERED(ID),
	CONSTRAINT FK_UserCaffeCaffe FOREIGN KEY (UserCaffeID) REFERENCES UserCaffe(ID)
);
GO

CREATE TABLE dbo.[Address] (
	ID int IDENTITY(1,1) NOT NULL,
	StreetNumber nvarchar(1024) NOT NULL,
	StreetName nvarchar(1024) NOT NULL,
	City nvarchar(1024) NOT NULL,
	PostCode nvarchar(1024),
	CaffeID int NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY CLUSTERED(ID),
	CONSTRAINT FK_CaffeAddress FOREIGN KEY (CaffeID) REFERENCES Caffe(ID)
);
GO

CREATE TABLE dbo.Deal (
	ID int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(1024) NOT NULL,
	[DateTime] dateTime NOT NULL,
	Points int NOT NULL,
	Price money NOT NULL,
	CaffeID int NOT NULL,
	Active bit DEFAULT 0,
	CONSTRAINT PK_Deal PRIMARY KEY CLUSTERED(ID),
	CONSTRAINT FK_CaffeDeal FOREIGN KEY (CaffeID) REFERENCES Caffe(ID)
);
GO

CREATE TABLE dbo.Transact (
	ID int IDENTITY(1,1) NOT NULL,
	[Time] dateTime NOT NULL,
	Amount money NOT NULL,
	UserCaffeID int NOT NULL,
	CONSTRAINT PK_Transact PRIMARY KEY CLUSTERED(ID),
	CONSTRAINT FK_UserCaffeTransact FOREIGN KEY (UserCaffeID) REFERENCES UserCaffe(ID)
);
GO

CREATE TABLE dbo.Feedback (
	ID int IDENTITY(1,1) NOT NULL,
	FeedbackLog nvarchar(max),
	CONSTRAINT PK_Feedback PRIMARY KEY CLUSTERED(ID)
);
GO

CREATE TABLE dbo.Challenge (
	ID int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(1024),
	[Description] nvarchar(max),
	CONSTRAINT PK_Challenge PRIMARY KEY CLUSTERED(ID)
);
GO
