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