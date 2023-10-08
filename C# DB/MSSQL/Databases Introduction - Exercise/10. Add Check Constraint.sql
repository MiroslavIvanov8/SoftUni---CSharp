USE MyFirstDB
--CREATE TABLE [Towns](
--[Id] INT PRIMARY KEY,
--[Name] NVARCHAR(50) NOT NULL,
--)
--CREATE TABLE [Minions](
--[Id] INT PRIMARY KEY,
--[Name] NVARCHAR(50) NOT NULL,
--[Age] INT NOT NULL,


ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) 

INSERT INTO [Towns]([Id],[Name])
	VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
	VALUES
(1,'Kevin',22, 1),
(2,'Bob',15, 3),
(3,'Steward',NULL, 2)

SELECT * FROM [Minions]
SELECT * FROM [Towns]

TRUNCATE TABLE [Minions]

GO
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH ([Picture]) <= 2000000),
	[Height] DECIMAL(3,2) DEFAULT (0), -- SETTING DEFAULT VALUE--
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
	)
INSERT INTO [People]([Name], [Height], [Weight],[Gender], [Birthdate])
	VALUES
	('Pesho',1.77,75.5,'m','1998-01-01'),
	('Mina',1.60,60.1,'f','2000-05-02'),
	('Mariya',1.80,69.2,'f','2003-10-10'),
	('Miroslav',1.85,74.2,'m','1998-10-01'),
	('Atanas',1.77,78.5,'m','2005-05-21')
Go

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH ([ProfilePicture]) <=900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT 
)
INSERT INTO [Users] VALUES
	('user1', 'pass1', NULL, NULL, 'False'),
	('user2', 'pass2', NULL, NULL, 'True'),
	('user3', 'pass3', NULL, NULL, 'True'),
	('user4', 'pass4', NULL, NULL, 'False'),
	('user5', 'pass5', NULL, NULL, 'False');
GO

USE [MyFirstDB]
ALTER TABLE [Users]
	DROP CONSTRAINT PK_Users;
	CHECK (DATALENGTH([Password]) >=5)

ALTER TABLE [Users]
	ADD CONSTRAINT PK_Users
	PRIMARY KEY (Id, Username);	
GO


ALTER TABLE [Users]
	ADD CONSTRAINT CHK_User_Password
	CHECK(LEN(Password) >= 5);


	--- MOVIES DATABASE
CREATE DATABASE [Movies]
USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(100)
)