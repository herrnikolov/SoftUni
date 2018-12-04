--01. Find Names of All Employees by First Name
USE SoftUni
GO

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--02. Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%EI%'

--03. Find First Names of All Employess
SELECT FirstName
FROM Employees
WHERE (DepartmentID = '3' OR DepartmentID = '10') AND (YEAR(HireDate) BETWEEN 1995 AND 2005)

--04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%Engineer%'

--05. Find Towns with Name Length
SELECT Name
FROM Towns
WHERE Name LIKE '_____' OR Name LIKE '______'
ORDER BY Name

--06. Find Towns Starting With
SELECT *
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name

--07. Find Towns Not Starting With
SELECT *
FROM Towns
WHERE Name LIKE '[^RBD]%'
ORDER BY Name
GO

--08. Create View Employees Hired After 2000
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM  Employees
WHERE YEAR(HireDate) > 2000
GO

--09. Length of Last Name
SELECT FirstName, LastName
FROM  Employees
WHERE LastName LIKE '_____'
--WHERE LEN(LastName) = 5
GO

--10. Countries Holding 'A' 3 or More Times
USE Geography
GO

SELECT CountryName AS [Country Name], IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

--11. Mix of Peak and River Names
USE Geography
GO

SELECT	p.PeakName,
		r.RiverName,
		LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName) -1)) AS Mix
FROM Rivers r, Peaks p
WHERE RIGHT (P.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix

--12. Games From 2001 and 2012 Year
USE Diablo
GO

SELECT 
	TOP 50 Name AS Game,
	SUBSTRING(CONVERT(VARCHAR, Start, 120), 1, 10) AS [Start]
FROM Games
WHERE YEAR(Start) >= 2011 and YEAR(Start) <= 2012
ORDER BY Start, Game

--13. User Email Providers
SELECT 
	Username,
	RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--14. Get Users with IPAddress Like Pattern
SELECT	Username, 
		IpAddress AS [IP Address] 
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--15. Show All Games with Duration and Part of the Day
SELECT
	Name as Game, 
	CASE WHEN DATEPART(HOUR, Start) >= 0 and DATEPART(HOUR, Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) >= 12 and DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) >= 18 and DATEPART(HOUR, Start) < 24 THEN 'Evening' END AS [Part of the Day], 
	CASE WHEN Duration <= 3 THEN 'Extra Short' WHEN Duration > 3 and Duration <= 6 THEN 'Short' WHEN Duration > 6 and Duration <= 10 THEN 'Long' ELSE 'Extra Long' END AS Duration 
FROM Games
ORDER BY Game, Duration, [Part of the Day]

--16. Orders table
CREATE DATABASE OTables;
USE OTables;
GO

CREATE TABLE Orders
(
	Id INT NOT NULL,
	ProductName VARCHAR(50) NOT NULL,
	OrderDate DATETIME NOT NULL
	CONSTRAINT PK_Orders PRIMARY KEY (Id)
)

INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (1, 'Butter', '20160919');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (2, 'Milk', '20160930');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (3, 'Cheese', '20160904');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (4, 'Bread', '20151220');
INSERT INTO Orders (Id, ProductName, OrderDate) VALUES (5, 'Tomatoes', '20150101');

SELECT
	ProductName,
	OrderDate,
DATEADD(DAY, 3, OrderDate) AS "Pay due",
DATEADD(MONTH, 1, OrderDate) AS "Order due"
FROM Orders;


--17. People table
CREATE TABLE People
(
	Id INT NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Birthday DATETIME NOT NULL
)

INSERT INTO People (Id, Name, Birthday) VALUES (1, 'Victor', '20001207');
INSERT INTO People (Id, Name, Birthday) VALUES (2, 'Steven', '19920910');
INSERT INTO People (Id, Name, Birthday) VALUES (3, 'Stephen', '19100919');
INSERT INTO People (Id, Name, Birthday) VALUES (4, 'John', '20100106');

SELECT 
	Name,
	Birthday,
	DATEDIFF(YEAR, Birthday, GETDATE()) as "Age in Years",
	DATEDIFF(MONTH, Birthday, GETDATE()) as "Age in Months",
	DATEDIFF(DAY, Birthday, GETDATE()) as "Age in Days",
	DATEDIFF(MINUTE, Birthday, GETDATE()) as "Age in Minutes"
FROM People