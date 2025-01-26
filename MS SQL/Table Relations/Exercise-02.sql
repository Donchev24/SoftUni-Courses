CREATE
 TABLE Manufacturers(
 [ManufacturerID] INT PRIMARY KEY,
 [Name] VARCHAR(60) NOT NULL,
 [EstablishedOn] DATETIME)

CREATE
 TABLE Models(
 [ModelID] INT PRIMARY KEY,
 [Name] VARCHAR(60) NOT NULL,
 [ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID))
