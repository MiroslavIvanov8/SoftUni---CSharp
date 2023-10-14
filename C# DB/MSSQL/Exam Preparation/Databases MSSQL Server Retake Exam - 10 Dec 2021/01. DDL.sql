
CREATE TABLE Passengers (
    [Id] INT PRIMARY KEY IDENTITY,
    [FullName] NVARCHAR(100) NOT NULL UNIQUE,
    [Email] NVARCHAR(50) NOT NULL UNIQUE
);


CREATE TABLE Pilots (
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(30) NOT NULL UNIQUE,
    [LastName] NVARCHAR(30) NOT NULL UNIQUE,
    [Age] TINYINT NOT NULL CHECK (Age >= 21 AND Age <= 62),
    [Rating] FLOAT CHECK (Rating >= 0.0 AND Rating <= 10.0)
);


CREATE TABLE AircraftTypes (
    [Id] INT PRIMARY KEY IDENTITY,
    [TypeName] NVARCHAR(30) NOT NULL UNIQUE
);


CREATE TABLE Aircraft (
    [Id] INT PRIMARY KEY IDENTITY,
    [Manufacturer] NVARCHAR(25) NOT NULL,
    [Model] NVARCHAR(30) NOT NULL,
    Year INT NOT NULL,
    [FlightHours] INT,
    [Condition] CHAR(1) NOT NULL,
    [TypeId] INT NOT NULL,
    FOREIGN KEY (TypeId) REFERENCES AircraftTypes(Id)
);


CREATE TABLE PilotsAircraft (
    [AircraftId] INT NOT NULL,
    [PilotId] INT NOT NULL,
    PRIMARY KEY (AircraftId, PilotId),
    FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id),
    FOREIGN KEY (PilotId) REFERENCES Pilots(Id)
);


CREATE TABLE Airports (
    [Id] INT PRIMARY KEY IDENTITY,
    [AirportName] NVARCHAR(70) NOT NULL UNIQUE,
    [Country] NVARCHAR(100) NOT NULL
);


CREATE TABLE FlightDestinations (
    [Id] INT PRIMARY KEY IDENTITY,
    [AirportId] INT NOT NULL,
    [Start] DATETIME NOT NULL,
    [AircraftId] INT NOT NULL,
    [PassengerId] INT NOT NULL,
    [TicketPrice] DECIMAL(18, 2) NOT NULL DEFAULT 15.00,
    FOREIGN KEY (AirportId) REFERENCES Airports(Id),
    FOREIGN KEY (AircraftId) REFERENCES Aircraft(Id),
    FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)
);