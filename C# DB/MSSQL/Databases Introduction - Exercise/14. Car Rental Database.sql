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

INSERT INTO [Directors]([DirectorName])
	VALUES
	('James Cameron'),
	('Paul Mcartney'),
	('Tom Hanks'),
	('Arthas'),
	('Pepe')

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(100)
)

INSERT INTO [Genres]([GenreName])
	VALUES
	('Drama'),
	('Horror'),
	('Adventure'),
	('Sci-fi'),
	('Romance')


CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(100),
)

INSERT INTO [Categories]([CategoryName])
	VALUES
	('Documentary'),
	('Adrenaline'),
	('Action'),
	('Historical'),
	('Gore')

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT REFERENCES [Directors]([Id]),
	[CopyrightYear] INT NOT NULL,
	[Length] INT NOT NULL,
	[GenreId] INT REFERENCES [Genres]([Id]),
	[CategoryId] INT REFERENCES [Categories]([Id]),
	[Rating] DECIMAL (2,1) NOT NULL,
	[Notes] TEXT,
)
INSERT INTO [Movies]([Title],[DirectorId], [CopyrightYear], [Length], [GenreId],[CategoryId], [Rating])
	VALUES
	('Avatar',1 ,2005,120 ,4 ,3 ,8.1),
	('BadAss',2, 2005,120,4 ,3, 8.1),
	('GunPoint',3, 2005,120,4 ,3 ,8.1),
	('The Last Air Bender',4, 2005 ,120 ,4 ,3 ,8.1),
	('Don John',5, 2010,110,4 ,3 ,5.0)

	-- Car Rental DB	
CREATE DATABASE [CarRental]
USE [CarRental] 

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(2,1) NOT NULL,
	[WeeklyRate] DECIMAL(2,1) NOT NULL,
	[MonthlyRate] DECIMAL(2,1) NOT NULL,
	[WeekendRate] DECIMAL(2,1) NOT NULL
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
	VALUES
	('SportCar',9.1,9.0,8.2,7.7),
	('Van',6.0,7.2,6.2,9.7),
	('FamilyCar',7.0,4.1,5.2,8.7)


CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT REFERENCES [Categories]([Id]),
	[Doors] TINYINT NOT NULL,
	[Picture] IMAGE,
	[Condition] NVARCHAR(20) NOT NULL,
	[Available] BIT NOT NULL,
)
INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
	VALUES
	('ABC123', 'Toyota', 'Camry', 2020, 1, 4, NULL, 'New', 1),
    ('XYZ456', 'Honda', 'Civic', 2019, 2, 4, NULL, 'Used', 1),
    ('DEF789', 'Ford', 'Focus', 2021, 3, 4, NULL, 'New', 1);

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(20),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
	VALUES
	('David', 'Johnson', 'Designer', 'Graphic designer skilled in Adobe Creative Suite.'),
    ('Sarah', 'Williams', 'Analyst', 'Data analyst experienced in SQL and data visualization.'),
    ('Michael', 'Brown', NULL, NULL);

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY,
	[DrivingLicenceNumber] NVARCHAR(12) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Adress] NVARCHAR(50) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[ZIPCode] INT,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [Customers]([DrivingLicenceNumber], [FullName], [Adress], [City], [ZIPCode], [Notes])
	VALUES
	('DL5678901234', 'David Johnson', '789 Oak Road', 'Chicago', 60601, 'First-time customer, referred by a friend.'),
    ('DL4321098765', 'Sarah Williams', '101 Pine Lane', 'Houston', 77002, NULL),
    ('DL6543210987', 'Michael Brown', '222 Cedar Drive', 'Miami', NULL, 'Corporate account holder with custom pricing.');

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT REFERENCES [Employees]([Id]),
	[CustomerId] INT REFERENCES [Customers]([Id]),
	[CarId] INT REFERENCES [Cars]([Id]),
	[TankLevel] DECIMAL(3,0) NOT NULL,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] DECIMAL(3,1) NOT NULL,
	[TaxRate] DECIMAL(2,1),
	[OrderStatus] BIT NOT NULL,
	[Notes] NVARCHAR(MAX),	
)


INSERT INTO [RentalOrders] (
    [EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart],
    [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays],
    [RateApplied], [TaxRate], [OrderStatus], [Notes]
)
VALUES
    (1, 1, 1, 75, 25000, 25300, 300, '2023-09-15', '2023-09-18', 3, 35.0, 7.5, 1, 'Rental for a weekend getaway.'),
    (2, 2, 2, 90, 18000, 18250, 250, '2023-09-16', '2023-09-19', 3, 40.0, NULL, 1, 'Extended rental due to travel.'),
    (3, 3, 3, 80, 31000, 31500, 500, '2023-09-17', '2023-09-20', 3, 38.5, 7.0, 1, NULL);

	GO

	-- HOTEL DATABASE
CREATE DATABASE [Hotel]
USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(MAX) NOT NULL,
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
VALUES
    ('John', 'Doe', 'Manager', 'Responsible for team management and project coordination.'),
    ('Jane', 'Smith', 'Developer', 'Frontend developer with expertise in JavaScript and React.'),
    ('David', 'Johnson', 'Designer', 'Graphic designer skilled in Adobe Creative Suite.')

CREATE TABLE [Customers](	
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] NVARCHAR(10) NOT NULL,
	[EmergencyName] NVARCHAR(50) NOT NULL,
	[EmergencyNumber] NVARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] (
    [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
	VALUES
	('David', 'Johnson', '1112223333', 'Debbie Johnson', '4445556666', 'First-time customer, referred by a friend.'),
    ('Sarah', 'Williams', '7778889999', 'Michael Williams', '8887776666', NULL),
    ('Michael', 'Brown', '9998887777', 'Michelle Brown', '1112223333', 'Corporate account holder with custom pricing.')

CREATE TABLE [RoomStatus](	
	[RoomStatus] BIT NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [RoomStatus] (
    [RoomStatus], [Notes]
)
VALUES
    (1, 'Room is currently occupied.'),
    (0, 'Room is vacant and ready for cleaning.'),
    (1, 'Room is reserved for an upcoming guest.')

CREATE TABLE [RoomTypes](
	[RoomType] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX),
)

INSERT INTO [RoomTypes] (
    [RoomType], [Notes]
)
VALUES
    ('Standard', 'Basic room with essential amenities.'),
    ('Deluxe', 'Upgraded room with additional comfort and features.'),
    ('Suite', 'Luxurious suite with spacious living areas.')

CREATE TABLE [BedTypes](	
	[BedType] TEXT NOT NULL,
	[Notes] TEXT
)

INSERT INTO [BedTypes] (
    [BedType], [Notes]
)
VALUES
    ('Single', 'A single bed suitable for one person.'),
    ('Double', 'A double bed designed for two people.'),
    ('Queen', 'A queen-sized bed providing extra space and comfort.')
	
CREATE TABLE [Rooms](	
	[RoomNumber] INT PRIMARY KEY IDENTITY ,
	[RoomType] TEXT NOT NULL,
	[BedType] TEXT NOT NULL,
	[Rate] DECIMAL (3,1) NOT NULL,
	[RoomStatus] BIT NOT NULL,
	[Notes] TEXT
)

INSERT INTO [Rooms] (
    [RoomType], [BedType], [Rate], [RoomStatus], [Notes]
)
VALUES
    ('Standard', 'Single', 50.0, 0, 'Room is vacant and ready for cleaning.'),
    ('Standard', 'Double', 65.5, 0, 'Room is vacant and ready for cleaning.'),
    ('Deluxe', 'Queen', 85.0, 1, 'Room is currently occupied by a guest.')

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT REFERENCES [Employees]([Id]),
	[PaymentDate] DATE NOT NULL,
	[AccountNumber] INT REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied] DATE,
	[LastDateOccupied] DATE,
	[TotalDays]	INT NOT NULL,
	[AmountCharget] DECIMAL (4,1) NOT NULL,
	[TaxRate] DECIMAL (2,1),
	[TaxAmount] DECIMAL(2,1),
	[PaymentTotal] DECIMAL (4,1)NOT NULL,
	[Notes] TEXT,
)

INSERT INTO [Payments] (
    [EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied],
    [LastDateOccupied], [TotalDays], [AmountCharget], [TaxRate],
    [TaxAmount], [PaymentTotal], [Notes]
)
VALUES
    (1, '2023-09-15', 1, '2023-09-12', '2023-09-15', 3, 150.0, 7.5, 1.5, 161.5, 'Payment for Room 101.'),
    (2, '2023-09-16', 2, '2023-09-14', '2023-09-16', 2, 131.0, NULL, NULL, 131.0, 'Payment for Room 202.'),
    (3, '2023-09-17', 3, '2023-09-16', '2023-09-17', 1, 185.0, 7.0, 5.5, 90.5, 'Payment for Room 303.')

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT REFERENCES [Employees]([Id]),
	[DateOccupied] DATE,
	[AccountNumber] INT REFERENCES [Customers]([AccountNumber]),
	[RoomNumber] INT REFERENCES [Rooms]([RoomNumber]),
	[RateApplied] DECIMAL (2,1),
	[PhoneCharge] VARCHAR(12),
	[Notes] TEXT,
)

INSERT INTO [Occupancies] (
    [EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber],
    [RateApplied], [PhoneCharge], [Notes]
)
VALUES
    (1, '2023-09-15', 1, 1, 5.0, '555-123-4567', 'Occupancy details for Room 101.'),
    (2, '2023-09-16', 2, 2, 5.5, '555-987-6543', 'Occupancy details for Room 202.'),
    (3, '2023-09-17', 3, 3, 5.0, '555-555-5555', 'Occupancy details for Room 303.')

