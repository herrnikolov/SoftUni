----Section 1. DDL (30 pts)
CREATE DATABASE ReportService
GO
USE ReportService
GO
--01.Database design
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50), 
	Gender CHAR(1) CHECK (Gender IN ('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	Email NVARCHAR(50)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK (Gender IN ('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME,
	CloseDate DATETIME,
	[Description] NVARCHAR(200),
	UserId INT  FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT  FOREIGN KEY REFERENCES Employees(Id)
)
GO
----Section 2. DML (10 pts)
--02.Insert
 INSERT INTO Employees(FirstName,LastName,Gender,Birthdate,DepartmentId)
 VALUES
('Marlo','O’Malley', 'M', '9/21/1958', '1'),
('Niki', 'Stanaghan', 'F', '11/26/1969', '4'),
('Ayrton', 'Senna', 'M', '03/21/1960' , '9'),
('Ronnie', 'Peterson', 'M', '02/14/1944', '9'),
('Giovanna', 'Amati', 'F', '07/20/1959', '5')


INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description],UserId,EmployeeId)
VALUES
('1', '1', '04/13/2017', NULL, 'Stuck Road on Str.133', '6', '2'),
('6', '3', '09/05/2015', '12/06/2015', 'Charity trail running', '3', '5'),
('14', '2', '09/07/2015',NULL , 'Falling bricks on Str.58', '5', '2'),
('4', '3', '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', '1', '1')
GO
--03. Update
--SELECT * FROM Reports WHERE CategoryId=4 AND StatusId=1

UPDATE Reports
SET StatusId = '2'
WHERE CategoryId='4' AND StatusId='1'
GO

--Switch all report’s 
--status to “in progress” where it is currently “waiting” 
--for the “Streetlight” category (look up the category ID and status ID’s manually, there is no need to use table joins).

--in progress = 2
--waiting = 1
--Streetlight = 1

--04. Delete
--Delete all reports who have a status “blocked”.
DELETE FROM Reports
WHERE StatusId = '4'
GO

----Section 3. Querying (40 pts)
--05.Users by Age
SELECT Username,
		Age
FROM Users
ORDER BY Age ASC, Username DESC
GO

--06. Unassigned Reports
SELECT [Description],
		OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]
GO

--07. Employees & Reports
SELECT
	e.FirstName,
	e.LastName,
	r.[Description],
	CONVERT(VARCHAR(10), OpenDate, 120)
FROM Employees AS e
JOIN Reports AS R
	ON r.EmployeeId = e.Id
ORDER BY e.Id,
	r.OpenDate,
	r.Id
GO
--08. Most Reported Category
SELECT
	 c.Name AS [CategoryName],
	 COUNT(r.CategoryId) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r 
	ON r.CategoryId=c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC,CategoryName
GO
--09. Employees in Category
SELECT
	c.Name AS CategoryName,
	COUNT(e.Id) 
FROM Categories AS c
JOIN Departments AS d ON d.Id=c.DepartmentId
JOIN Employees AS e ON e.DepartmentId=c.DepartmentId
GROUP BY c.Name
ORDER BY c.Name
GO
--10. Users per Employee
SELECT 
	e.FirstName + ' ' + e.LastName AS [Name],
	COUNT(DISTINCT r.UserId) AS [Users Number]
FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId=e.Id
GROUP BY e.FirstName + ' ' + e.LastName
ORDER BY 
		COUNT(DISTINCT r.UserId) DESC, 
		e.FirstName + ' ' + e.LastName
GO

--11. Emergency Patrol
SELECT 
	r.OpenDate,
	r.[Description],
	u.Email
FROM Reports AS r
JOIN Users AS u ON u.Id=r.UserId
JOIN Categories AS c ON c.Id=r.CategoryId
JOIN Departments AS d ON d.Id=c.DepartmentId
WHERE 
	r.CloseDate IS NULL
AND (LEN(r.Description) > 20 AND r.Description LIKE '%str%')
AND d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY r.OpenDate, u.Email, r.Id
GO

--12.Birthday Report
SELECT
		c.Name AS [Category Name]
  FROM	Categories AS c
JOIN Reports AS r ON r.CategoryId=c.Id
JOIN Users AS u ON u.Id=r.UserId
WHERE DAY(u.BirthDate) = DAY(r.OpenDate)
AND	  MONTH(u.BirthDate) = MONTH(r.OpenDate)
GROUP BY c.Name
ORDER BY c.Name
GO
--or
SELECT
		c.Name AS [Category Name]
  FROM	Categories AS c
JOIN Reports AS r ON r.CategoryId=c.Id
JOIN Users AS u ON u.Id=r.UserId
WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY,u.BirthDate)
AND DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH,u.BirthDate)
GROUP BY c.Name
GO

--13. Numbers Coincidence
SELECT DISTINCT(u.Username)
FROM Users AS u
JOIN Reports AS r ON r.UserId=u.Id
JOIN Categories AS c ON c.Id=r.CategoryId
WHERE 	(ISNUMERIC(LEFT(u.Username, 1)) = 1 AND CAST(LEFT(u.Username, 1) AS INT) = r.CategoryId)
OR		(ISNUMERIC(RIGHT(u.Username, 1)) = 1 AND CAST(RIGHT(u.Username, 1) AS INT) = r.CategoryId)
ORDER BY u.Username
GO
--or
SELECT DISTINCT(u.Username)
FROM Users AS u
JOIN Reports AS r ON r.UserId=u.Id
JOIN Categories AS c ON c.Id=r.CategoryId
WHERE (u.Username LIKE '[0-9]%' AND CAST(r.CategoryId AS CHAR)=SUBSTRING(u.Username,1,1))
   OR (u.Username LIKE '%[0-9]' AND CAST(r.CategoryId AS CHAR)=SUBSTRING(u.Username,LEN(u.UserName),1))
	
ORDER BY u.Username
GO
-- or
SELECT DISTINCT(u.Username)
FROM Users AS u
JOIN Reports AS r ON r.UserId=u.Id
JOIN Categories AS c ON c.Id=r.CategoryId
WHERE 	(ISNUMERIC(LEFT(u.Username, 1)) = 1 AND CAST(LEFT(u.Username, 1) AS INT) = r.CategoryId)
OR		(ISNUMERIC(RIGHT(u.Username, 1)) = 1 AND CAST(RIGHT(u.Username, 1) AS INT) = r.CategoryId)
ORDER BY u.Username
GO

--14. Open/Closed Statistics



