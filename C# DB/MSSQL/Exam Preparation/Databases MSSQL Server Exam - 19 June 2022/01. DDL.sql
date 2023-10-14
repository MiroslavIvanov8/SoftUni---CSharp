CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
);

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
);

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT REFERENCES AnimalTypes(Id) NOT NULL
);

CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT REFERENCES Owners(Id),
	AnimalTypeId INT REFERENCES AnimalTypes(Id) NOT NULL
);

CREATE TABLE AnimalsCages(
	CageId INT REFERENCES  Cages(Id) NOT NULL,
	AnimalId INT REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY (CageId, AnimalId)
);

CREATE TABLE VolunteersDepartments (
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
);

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT REFERENCES Animals(Id),
	DepartmentId INT REFERENCES VolunteersDepartments(Id) NOT NULL
);