--Problem 01. Create Database
USE master
GO
CREATE DATABASE Minions
GO

--Problem 02. Create Tables
USE Minions
GO

CREATE TABLE Minions
(
	Id INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Age INT
	CONSTRAINT PK_Minions PRIMARY KEY(Id)
)
CREATE TABLE Towns
(
	Id INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY(Id)
)

--Problem 03. Alter Minions Table
USE Minions
GO 
ALTER TABLE Minions
ADD TownId INT
CONSTRAINT FK_Minions_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)

SELECT * FROM Minions

--Problem 04. Insert Records in Both Tables
USE Minions
GO

INSERT INTO Towns(Id,Name)
VALUES (1, 'Sofia'), (2, 'Plovdiv'), (3, 'Varna')

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, 1), (2, 'Bob', 15, 3), (3, 'Steward', NULL, 2)

SELECT * FROM Minions
SELECT * FROM Towns

--Problem 05. Truncate Table Minions
USE Minions
GO

TRUNCATE TABLE Minions

--Problem 06. Drop All Tables
USE Minions
GO

DROP TABLE Towns
DROP TABLE Minions

--Problem 07. Create Table People
USE Minions
GO

CREATE TABLE People (
--	Id INT IDENTITY UNIQUE NOT NULL,
    Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height NUMERIC(10,2),
	Weight NUMERIC(10,2),
	Gender CHAR(1) NOT NULL CONSTRAINT chk_Gender CHECK (Gender IN ('m', 'f')),
	Birtdate DATE  NOT NULL,
	Biograpy NTEXT,
--	CONSTRAINT PK_People PRIMARY KEY (Id)
)

INSERT INTO People (Name,Picture,Height,Weight,Gender,Birtdate,Biograpy)
VALUES
('Name1', NULL, 1.99, 99.00, 'M', '01.01.1999', 'Bio1'),
('Name2', NULL, 1.89, 89.00, 'M', '01.01.1989', 'Bio2'),
('Name3', NULL, 1.79, 79.00, 'F', '01.01.1979', 'Bio3'),
('Name4', NULL, 1.69, 69.00, 'F', '01.01.1969', 'Bio4'),
('Name5', NULL, 1.59, 59.00, 'F', '01.01.1959', 'Bio5')

SELECT * FROM People

--DROP TABLE People
--TRUNCATE TABLE People

--Problem 08. Create Table Users
USE Minions
GO

CREATE TABLE Users
(
--	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Id BIGINT IDENTITY UNIQUE NOT NULL,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATE,
	IsDeleted BIT
	CONSTRAINT PK_Users PRIMARY KEY (Id)
)
INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('user1', 'password1', NULL, GETDATE(), 0),
('user2', 'password2', NULL, GETDATE(), 1),
('user3', 'password3', NULL, GETDATE(), 0),
('user4', 'password4', NULL, GETDATE(), 1),
('user5', 'password5', NULL, GETDATE(), 0)

SELECT * FROM Users

--DROP TABLE Users

--Problem 9. Change Primary Key
USE Minions
GO

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)

--Problem 10. Add Check Constraint
USE Minions
GO

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordLength CHECK (LEN(Password) > 5)

--Problem 11. Set Default Value of a Field
USE Minions
GO

ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

--Problem 12. Set Unique Field
USE Minions
GO

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT UC_Username UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT UC_UsernameLenght CHECK (LEN(Username) >=3)

--Problem 13. Movies Database
CREATE DATABASE Movies
GO
USE Movies
GO

CREATE TABLE Directors
(
	Id INT IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Directors PRIMARY KEY (Id)
)
CREATE TABLE Genres
(
	Id INT IDENTITY NOT NULL,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Generes PRIMARY KEY (Id)
)
CREATE TABLE Categories
(
	Id INT IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Categories PRIMARY KEY (Id)
)
CREATE TABLE Movies
(
	Id INT IDENTITY NOT NULL,
	Title NVARCHAR (50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrithYear SMALLINT,
	Length INT,
	GenereId INT,
	CategoryId INT,
	Rating NUMERIC,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Movies PRIMARY KEY (Id)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES
('Jon Favreau','Notes01'),
('Bahman Ghobadi','Notes02'),
('Jeff Nichols','Notes03'),
('Edgar Wright','Notes04'),
('Hirokazu Koreeda','Notes05')

INSERT INTO Genres(GenreName,Notes)
VALUES
('Action','Note01'),
('Comedy','Note02'),
('SciFi','Note03'),
('Drama','Note04'),
('Horror','Note05')

INSERT INTO Categories(CategoryName,Notes)
VALUES
('G','Note01'),
('PG','Note02'),
('PG-13','Note03'),
('R','Note04'),
('NC-17','Note05')

INSERT INTO Movies(Title, DirectorId, CopyrithYear, Length, GenereId, CategoryId, Rating, Notes )
VALUES
('IronMan',1,2000,120,1,1,9.0,'Movie Note01'),
('Batman',2,2001,130,2,2,8.0,'Movie Note01'),
('IronMan',3,2002,140,3,3,7.0,'Movie Note01'),
('IronMan',4,2003,150,4,4,6.0,'Movie Note01'),
('IronMan',5,2004,160,5,5,5.0,'Movie Note01')

SELECT * FROM Directors
SELECT * FROM Genres
SELECT * FROM Categories
SELECT * FROM Movies

--Problem 14. Car Rental Database
CREATE DATABASE CarRental
GO

USE CarRental
GO

CREATE TABLE Categories
(
	Id INT IDENTITY NOT NULL,
	Category NVARCHAR(50) NOT NULL,
	DailyRate NUMERIC,
	WeeklyRate NUMERIC,
	MonthlyRate NUMERIC,
	WeekendRate NUMERIC
	CONSTRAINT PK_Categories PRIMARY KEY (Id)
)

CREATE TABLE Cars
(
	Id INT IDENTITY NOT NULL,
	PlateNumber NVARCHAR(10) NOT NULL,
	Make NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear INT,
	CategoryId INT,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	IsAvailable BIT
	CONSTRAINT PK_Cars PRIMARY KEY (Id)
)
CREATE TABLE Employees
(
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Employees PRIMARY KEY (Id)
)
CREATE TABLE Customers
(
	Id INT IDENTITY NOT NULL,
	DriverLicenceNumber NVARCHAR(20) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	Address NVARCHAR(500),
	City NVARCHAR(50),
	ZIPCode NVARCHAR(20),
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Customers PRIMARY KEY (Id)
)
CREATE TABLE RentalOrders
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	CarCondition NVARCHAR(MAX),
	TankLevel NUMERIC(10,2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT,
	TaxRate NUMERIC,
	OrderStatus NVARCHAR(10),
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_RentalOrders PRIMARY KEY (Id)
)

INSERT INTO Categories (Category)
VALUES ('Car'), ('SUV'), ('MiniVan')

INSERT INTO Cars (PlateNumber, Make, Model)
VALUES
('C1234YY', 'Subaru', 'OutBack'),
('B1234XX', 'Toyota', 'Corolla'),
('OB1234ZZ', 'Lada', 'Niva')

INSERT INTO Employees (FirstName, LastName)
VALUES
('Ivan', 'Ivanov'),
('Petar', 'Petrov'),
('Kiro', 'Kirov')

INSERT INTO Customers (DriverLicenceNumber, FullName)
VALUES
('A12345', 'Ivan Ivanov Ivanov'),
('B12345', 'Ivan Ivanov Petrov'),
('C12345', 'Kiro Kirov Kirov')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId)
VALUES
(1, 2, 3),
(2, 3, 1),
(2, 2, 2)

SELECT * FROM Categories
SELECT * FROM Cars
SELECT * FROM Employees
SELECT * FROM Customers
SELECT * FROM RentalOrders

--DROP DATABASE CarRental

--Problem 15. Hotel Database
CREATE DATABASE Hotel
GO
USE Hotel
GO

CREATE TABLE Employees
(
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Employees PRIMARY KEY (Id)
)
CREATE TABLE Customers
(
	AccountNumber BIGINT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(20) NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber NVARCHAR(20),
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Customers PRIMARY KEY (AccountNumber)
)
CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_RoomStatus PRIMARY KEY (RoomStatus)
)
CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_RoomTypes PRIMARY KEY (RoomType)
)
CREATE TABLE BedTypes
(
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_BedTypes PRIMARY KEY (BedType)
)
CREATE TABLE Rooms
(
	RoomNumber INT NOT NULL,
	RoomType NVARCHAR(20) NOT NULL,
	BedType NVARCHAR(20) NOT NULL,
	Rate NUMERIC,
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Rooms PRIMARY KEY (RoomNumber)
)
CREATE TABLE Payments
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber BIGINT NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged NUMERIC NOT NULL,
	TaxRate NUMERIC,
	TaxAmount NUMERIC,
	PaymentTotal NUMERIC NOT NULL,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Payments PRIMARY KEY (Id)
)
CREATE TABLE Occupancies
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATE,
	AccountNumber BIGINT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied NUMERIC,
	PhoneCharge NUMERIC,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Occupancies PRIMARY KEY (Id)
)

INSERT INTO Employees (FirstName, LastName)
VALUES
('Ivan', 'Ivanov'),
('Petar', 'Petrov'),
('Dimitar', 'Dimitrov')

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber)
VALUES
(09876543210, 'Petar', 'Petrov', '+359888000888'),
(12345678901, 'Mihail', 'Mihailov', '+359999000999'),
(74185296300, 'Nikolay', 'Nikolaev', '+359777000777')

INSERT INTO RoomStatus (RoomStatus)
VALUES
('Occupied'),
('Available'),
('Cleaning')

INSERT INTO RoomTypes (RoomType)
VALUES
('Single'),
('Double'),
('Apartment')

INSERT INTO BedTypes (BedType)
VALUES
('Double'),
('Queen'),
('King')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, RoomStatus)
VALUES
(1, 'Single', 'Double', 'Available'),
(2, 'Double', 'King', 'Cleaning'),
(12, 'Apartment', 'Queen', 'Occupied')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, AmountCharged, PaymentTotal, TaxRate)
VALUES
(1, GETDATE(), 00000000001, 80.00, 12.20, 2.4),
(3, GETDATE(), 00000000002, 220.00, 240.22, 2.1),
(2, GETDATE(), 00000000003, 390.90, 215.88, 1.1)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber)
VALUES
(1, 00000000001, 2),
(2, 00000000002, 1),
(2, 00000000003, 12)

SELECT * FROM Employees
SELECT * FROM Customers
SELECT * FROM RoomStatus
SELECT * FROM RoomTypes
SELECT * FROM BedTypes
SELECT * FROM Rooms
SELECT * FROM Payments
SELECT * FROM Occupancies

--Problem 16. Create SoftUni Database
CREATE DATABASE SoftUni
GO

USE SoftUni
GO

CREATE TABLE Towns
(
	Id INT IDENTITY,
	Name NVARCHAR(50)
	CONSTRAINT PK_TownsId PRIMARY KEY (Id)
)
CREATE TABLE Addresses
(
	Id INT IDENTITY,
	AddressText NVARCHAR(100),
	TownId INT,
	CONSTRAINT PK_AddressesId PRIMARY KEY(Id),
	CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)
)
CREATE TABLE Departments
(
	Id INT IDENTITY,
	Name NVARCHAR(50),
	CONSTRAINT PK_DepartmentsId PRIMARY KEY (Id)
)
CREATE TABLE Employees
(
	Id INT IDENTITY,
	FirstName NVARCHAR(50),
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50),
	JobTitle NVARCHAR(20),
	DepartmentId INT,
	HireDate DATE,
	Salary MONEY,
	AddressId INT
	CONSTRAINT PK_EmployeesID PRIMARY KEY(Id),
	CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments (Id),
	CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
)

--Problem 17. Backup Database
BACKUP DATABASE SoftUni
	TO DISK = 'C:\Backups\SoftUni_Full.bak'
	WITH FORMAT,
	MEDIANAME = '',
	NAME = 'SoftUni Full Backup';
GO

RESTORE DATABASE SoftUni
FROM DISK = 'C:\Backups\SoftUni_Full.bak'
GO

--Problem 18. Basic Insert
USE SoftUni
GO

INSERT INTO Towns (Name)
VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Departments (Name) 
VALUES ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) 
VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)

--Problem 19. Basic Select All Fields
USE SoftUni
GO

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20. Basic Select All Fields and Order Them
USE SoftUni
GO

SELECT * FROM Towns 
ORDER BY Name

SELECT * FROM Departments
ORDER BY Name

SELECT * FROM Employees
ORDER BY Salary DESC


--Problem 21. Basic Select Some Fields
USE SoftUni
GO

SELECT Name FROM Towns 
ORDER BY Name

SELECT Name FROM Departments
ORDER BY Name

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--Problem 22. Increase Employees Salary
USE Softuni
GO

SELECT Salary FROM Employees
UPDATE Employees
set Salary *= 1.1
SELECT Salary FROM Employees

--Problem 23. Decrease Tax Rate
USE Hotel
GO

UPDATE Payments
SET TaxRate -= TaxRate * 0.03
SELECT TaxRate FROM Payments

--Problem 24. Delete All Records
USE Hotel
GO

DELETE FROM Occupancies
SELECT COUNT(*) FROM Occupancies