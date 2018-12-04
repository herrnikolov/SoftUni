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
