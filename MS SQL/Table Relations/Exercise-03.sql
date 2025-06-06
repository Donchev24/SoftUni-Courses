CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY,
[Name] VARCHAR(60) NOT NULL
)

CREATE TABLE [Exams](
[ExamID] INT PRIMARY KEY,
[Name] VARCHAR(60) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
)
