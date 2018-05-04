--01. One-To-One Relationship

CREATE DATABASE Relationships
GO
USE Relationships
GO

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(50)
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY,
	FirstName VARCHAR(50),
	Salary DECIMAL (10,2),
	PassportID	INT,
	CONSTRAINT FK_Persons_Passports
	FOREIGN KEY(PassportID)
	REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

--02. One-To-Many Relationship
CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) UNIQUE NOT NULL,
	EstablishedOn DATE
)
CREATE TABLE Models
(
	ModelsID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(100),
	ManufacturerID INT
	FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers ([Name], EstablishedOn)
VALUES 
	('BMW', '19160307'),
	('Tesla', '20030101'),
	('Lada', '19660501')

INSERT INTO Models ([Name], ManufacturerID)
VALUES 
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

--03. Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	[Name] VARCHAR(50)
)
CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY,
	[Name] VARCHAR(50)
)
CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT,
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudnetsExams_Students
		FOREIGN KEY(StudentID)
		REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams
		FOREIGN KEY(ExamID)
		REFERENCES Exams(ExamID)
)
INSERT INTO Students(StudentID, Name)
VALUES
	(1, 'Mila'),                                     
	(2, 'Toni'),
	(3, 'Ron')

INSERT INTO Exams(ExamID, Name)
VALUES 
	(101, 'Spring MVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--04. Self-Referencing
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY,
	[Name] VARCHAR(50),
	ManagerID INT,
	CONSTRAINT FK_Teachers_Teacher
	FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)
INSERT INTO Teachers(TeacherID, Name, ManagerID)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

--05. Online Store Database
CREATE DATABASE OnLineStore
GO
USE OnLineStore
GO

CREATE TABLE Cities(
	CityID INT,
	Name VARCHAR(50),
	CONSTRAINT PK_Cities PRIMARY KEY(CityID)
)

CREATE TABLE Customers(
	CustomerID INT,
	Name VARCHAR(50),
	Birthday DATE,
	CityID INT,
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID)
)

CREATE TABLE Items(
	ItemID INT,
	Name VARCHAR(50),
	ItemTypeID INT,
	CONSTRAINT PK_Items PRIMARY KEY(ItemID)
)

CREATE TABLE ItemTypes(
	ItemTypeID INT,
	Name VARCHAR(50),
	CONSTRAINT PK_ItemTypes PRIMARY KEY(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT,
	ItemID INT,
	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID)
)

CREATE TABLE Orders(
	OrderID INT,
	CustomerID INT,
	CONSTRAINT PK_Orders PRIMARY KEY(OrderID)
) 

ALTER TABLE Customers 
ADD CONSTRAINT FK_Customers_Cities
	FOREIGN KEY(CityID) REFERENCES Cities(CityID)

ALTER TABLE Items 
ADD CONSTRAINT FK_Items_ItemTypes
	FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Items
	FOREIGN KEY(ItemID) REFERENCES Items(ItemID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Orders
	FOREIGN KEY(OrderID) REFERENCES Orders(OrderID)

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers
FOREIGN KEY(CustomerID) REFERENCES Customers (CustomerID)

--06. University Database
CREATE DATABASE UniversityDB
GO
USE UniversityDB
GO

CREATE TABLE Majors
(
  MajorID INT IDENTITY PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
  StudentID INT IDENTITY PRIMARY KEY,
  StudentNumber INT UNIQUE NOT NULL,
  StudentName VARCHAR(255),
  MajorID INT NOT NULL
    FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Subjects
(
  SubjectID INT IDENTITY PRIMARY KEY,
  [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
  StudentID INT NOT NULL
	FOREIGN KEY REFERENCES Students(StudentID),
  SubjectID INT NOT NULL
	FOREIGN KEY REFERENCES Subjects(SubjectID),

  CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments
(
  PaymentID INT IDENTITY PRIMARY KEY,
  PaymentDate DATE NOT NULL,
  PaymentAmount DECIMAL(8, 2) NOT NULL,
  StudentID INT
	FOREIGN KEY REFERENCES Students(StudentID)
)

--09. Peaks in Rila
USE Geography
GO

SELECT
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
INNER JOIN Mountains AS m
	ON m.Id = p.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC