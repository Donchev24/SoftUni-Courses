CREATE
 TABLE [Majors](
       [MajorID] INT PRIMARY KEY,
	   [Name] VARCHAR(40) NOT NULL)

CREATE
 TABLE [Students](
       [StudentID] INT PRIMARY KEY,
	   [StudentNumber] VARCHAR(40) NOT NULL,
	   [StudentName] VARCHAR(40) NOT NULL,
	   [MajorID] INT NOT NULL FOREIGN KEY REFERENCES [Majors](MajorID))

CREATE
 TABLE [Payments](
       [PaymentID] INT PRIMARY KEY,
	   [PaymentDate] DateTime2,
	   [PaymentAmount] DECIMAL(18,2) NOT NULL,
	   [StudentID] INT NOT NULL FOREIGN KEY REFERENCES [Students](StudentID))

CREATE
 TABLE [Subjects](
       [SubjectID] INT PRIMARY KEY,
	   [SubjectName] VARCHAR(60) NOT NULL)

CREATE
 TABLE [Agenda](
       [StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID),
	   [SubjectID] INT FOREIGN KEY REFERENCES [Subjects](SubjectID),
	   CONSTRAINT [FK_StudentID_SubjectID] PRIMARY KEY (StudentID, SubjectID) )