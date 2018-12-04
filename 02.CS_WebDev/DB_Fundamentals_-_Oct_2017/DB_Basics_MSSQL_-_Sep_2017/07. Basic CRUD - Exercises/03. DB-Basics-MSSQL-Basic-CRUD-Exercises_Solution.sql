--Basic CRUD Exercies

USE SoftUni
GO

--Problem 02. Find All Information About All Departments
SELECT * 
FROM Departments

--Problem 03. Find All Department Names
SELECT Name 
FROM Departments

--Problem 04. Find Salary of Each Employee
SELECT 
	FirstName, LastName, Salary 
FROM Employees

--Problem 05. Find Full Name of Each Employee
SELECT 
	FirstName, MiddleName, LastName
FROM Employees

--Problem 06. Find Email Address of Each Employee
SELECT
	FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
FROM Employees

--Problem 07. Find All Different Employee's Salaries
SELECT
	DISTINCT Salary
FROM Employees

--Problem 08. Find All Information About Employees
SELECT
	*
FROM Employees
WHERE JobTitle = 'Sales Representative'

--Problem 09. Find Names of All Employees by Salary in Range
SELECT
	FirstName, LastName, JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 and 30000

--Problem 10. Find Names of All Employees
SELECT
	FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

--SELECT
--	CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
--FROM Employees
--WHERE Salary IN (25000, 14000, 12500, 23600)

--Problem 11. Find All Employees Without Manager
SELECT
	FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL

--Problem 12. Find All Employees with Salary More Than 50000
SELECT
	FirstName, LastName, Salary
FROM Employees
WHERE SALARY > 50000
ORDER BY Salary DESC

--Problem 13. Find Fice Best Paid Employees
SELECT
	TOP 5
	Firstname, LastName
FROM Employees
ORDER BY Salary DESC

--Problem 14. Find All Employees Except Marketing
SELECT
	FirstName, LastName
FROM Employees
WHERE DepartmentID <> 4

--Problem 15. Sort Employees Table
SELECT
	*
FROM Employees
ORDER BY Salary DESC,
		FirstName ASC,
		LastName DESC,
		MiddleName ASC

--Problem 16. Create View Employees with Salaries
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName,LastName, Salary
FROM Employees
GO

SELECT * 
FROM V_EmployeesSalaries

--Problem 17. Create View Employees with Job Titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
	FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name],
	JobTitle
FROM Employees
GO

SELECT * 
FROM V_EmployeeNameJobTitle
GO

--Problem 18. Distinct Job Titles
SELECT DISTINCT JobTitle 
FROM Employees

--Problem 19. Find First 10 Started Projects
SELECT 
	TOP 10 *
FROM Projects
ORDER BY 
	StartDate ASC,
	Name ASC
GO

--Problem 20. Last 7 Hired Employees
SELECT TOP 7
	FirstName,LastName,HireDate
FROM Employees
ORDER BY HireDate DESC

--Problem 21. Increase Salaries
UPDATE Employees
SET Salary = Salary + Salary * 0.12
WHERE DepartmentID IN (1, 2, 4, 11)
GO

SELECT Salary
FROM Employees

--Problem 22. All Mountain Peaks
USE Geography
GO

SELECT PeakName
FROM Peaks
ORDER BY PeakName

--Problem 23. Biggest Countries by Population
USE Geography
GO

SELECT
	TOP 30
	CountryName, Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY 
	Population DESC,
	CountryName

--Problem 24. Countries and Currency (Euro / Not Euro)
SELECT
	CountryName, CountryCode,
	(CASE WHEN CurrencyCode = 'EUR' THEN 'Euro' ELSE 'Not Euro' END) as Currency 
FROM Countries
ORDER BY CountryName

--Problem 25. All Diablo Characters
USE Diablo
GO

SELECT 
	Name
FROM Characters
ORDER BY Name