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

--TRUNCATE TABLE Minions

--Problem 06. Drop All Tables
USE Minions
GO

--DROP TABLE Towns
--DROP TABLE Minions

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

