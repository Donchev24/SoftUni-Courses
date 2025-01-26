CREATE
 TABLE Passports(
       [PassportID] VARCHAR(40) PRIMARY KEY,
       [PassportNumber] VARCHAR(40))

CREATE
 TABLE Persons(
       [PersonID] INT PRIMARY KEY,
       [FirstName] VARCHAR(60) NOT NULL,
       [Salary] DECIMAL(18,2),
       [PassportID] VARCHAR(40) FOREIGN KEY REFERENCES Passports(PassportID))


INSERT 
  INTO Passports
VALUES (101, 'N34FG21B'),
       (102, 'K65LO4R7'),
	   (103, 'ZE657QP2')

    ALTER TABLE Persons
 ADD CONSTRAINT [UQ_PassportID]
         UNIQUE (PassportID)

 INSERT 
   INTO Persons
 VALUES (1, 'Roberto', 43300.00, 102),
        (2, 'Tom', 56100.00, 103), 
		(3, 'Yana', 60200.00, 101)
