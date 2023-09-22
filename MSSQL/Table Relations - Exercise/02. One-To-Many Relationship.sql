CREATE TABle  Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
);

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50),
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Manufacturers([Name],EstablishedOn)
VALUES
	('BMW', '1916-03-07'),
	('Tesla', '2003-01-01'),
	('Lada', '1966-05-01');

INSERT INTO Models
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3);
	CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	);
	
	INSERT INTO Students([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

	CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(100,1),
	[Name] NVARCHAR(50) NOT NULL,
	);

	INSERT INTO Exams([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

	CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
	);

	INSERT INTO StudentsExams(StudentID,ExamID)
	VALUES
	(1,101),
	(1,102),
	(2,101),
	(3,103),
	(2,102),
	(2,103),



















CREATE TABle  Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
EstablishedOn DATE NOT NULL
);

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50),
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Manufacturers([Name],EstablishedOn)
VALUES
	('BMW', '1916-03-07'),
	('Tesla', '2003-01-01'),
	('Lada', '1966-05-01');

INSERT INTO Models
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3);















