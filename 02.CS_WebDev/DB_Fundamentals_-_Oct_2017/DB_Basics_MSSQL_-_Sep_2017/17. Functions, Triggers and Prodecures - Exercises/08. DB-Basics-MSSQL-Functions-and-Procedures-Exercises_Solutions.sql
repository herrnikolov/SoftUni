--01. Employees with Salary Above 35000
USE SoftUni
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
	SELECT
		FirstName,
		LastName	
	FROM Employees
	WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000 
GO
--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number MONEY
AS
	SELECT
		FirstName,
		LastName
	FROM Employees
	WHERE Salary >= @number
GO

EXEC usp_GetEmployeesSalaryAboveNumber  48100

--03. Towns Starting With
CREATE PROCEDURE usp_GetTownsStartingWith @prefix VARCHAR(MAX)
AS
SELECT [Name]
FROM Towns
WHERE [Name] LIKE CONCAT(@prefix, '%')
GO

EXEC usp_GetTownsStartingWith b
GO

--04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
	SELECT FirstName, 
			LastName 
	FROM Employees
	JOIN Addresses ON Employees.AddressID = Addresses.AddressID
	JOIN Towns ON Addresses.TownID = Towns.TownID
	WHERE Towns.[Name] = @townName
GO

EXEC usp_GetEmployeesFromTown Sofia
GO

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END;
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END;
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END;
	RETURN @salaryLevel
END
GO

SELECT FirstName, 
		LastName, 
		Salary, 
		dbo.ufn_GetSalaryLevel(Salary) 
  FROM Employees
WHERE Salary < 100000
GO

--6. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(MAX)
AS
	SELECT FirstName, 
			LastName 
		FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
GO

EXEC usp_EmployeesBySalaryLevel 'low'
GO

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised
	(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1;
	WHILE @counter <= LEN(@word)
	BEGIN
		DECLARE @char VARCHAR = SUBSTRING(@word, @counter, 1);
		IF(CHARINDEX(@char, @setOfLetters, 1) = 0)
		BEGIN
			RETURN 0
		END
		SET @counter = @counter + 1
	END
	RETURN 1
END
GO
SELECT [Name] 
FROM Towns
WHERE dbo.ufn_IsWordComprised('afiso', [Name]) = 1

--08. *Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
          AS
 ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
      WHERE EmployeeID IN 
			(
				SELECT EmployeeID FROM Employees
				WHERE DepartmentID = @departmentId
			)

UPDATE Employees
   SET ManagerID = NULL
 WHERE ManagerID IN 
	   (
			SELECT EmployeeID FROM Employees
			WHERE DepartmentID = @departmentId
	   )


UPDATE Departments
   SET ManagerID = NULL
 WHERE ManagerID IN 
	   (
			SELECT EmployeeID FROM Employees
			WHERE DepartmentID = @departmentId
	   )

DELETE FROM Employees
      WHERE EmployeeID IN 
			(
				SELECT EmployeeID FROM Employees
				WHERE DepartmentID = @departmentId
			)

              DELETE FROM Departments
                    WHERE DepartmentID = @departmentId
       SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
INNER JOIN Departments AS d
                       ON d.DepartmentID = e.DepartmentID
                    WHERE e.DepartmentID = @departmentId
					   GO


--09. Find Full Name
CREATE PROC usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName AS [Full Name] 
	FROM AccountHolders
GO

EXEC usp_GetHoldersFullName
GO

--10. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @balance MONEY
AS
	SELECT FirstName, 
			LastName 
	   FROM AccountHolders
	JOIN Accounts ON Accounts.AccountHolderId = AccountHolders.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @balance
GO

EXEC usp_GetHoldersWithBalanceHigherThan 10000
GO

--11.Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @rate FLOAT, @years FLOAT)
RETURNS MONEY
AS
BEGIN
	DECLARE @fv MONEY = @sum * POWER((1 + @rate), @years)
	RETURN @fv
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)
SELECT dbo.ufn_CalculateFutureValue(1000, 0.08, 5) 
SELECT dbo.ufn_CalculateFutureValue(1000, 0.04, 2)
SELECT dbo.ufn_CalculateFutureValue(1000.21, 0.02, 1) 
SELECT dbo.ufn_CalculateFutureValue(1000.98, 0.05, 3) 
GO

--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount @accountID INT, @rate FLOAT
AS
	SELECT 
		acc.Id,
		FirstName,
		LastName,
		Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(Balance, @rate, 5) AS [Balance in 5 years]
	FROM Accounts acc
	JOIN AccountHolders ah ON acc.AccountHolderId = ah.Id
	WHERE acc.Id = @accountID
GO

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1
GO

--13. *Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
RETURNS TABLE
AS RETURN
WITH prices AS(
	SELECT Cash, 
			(ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)) AS RowNum 
		FROM UsersGames ug
	JOIN Games g on ug.GameId = g.Id
	WHERE g.Name = @gameName
)
SELECT SUM(Cash) [SumCash] FROM prices WHERE RowNum % 2 = 1
GO

--Lab
USE SoftUni
GO

CREATE OR ALTER FUNCTION udf_GetSalaryLevel(@Salary INT)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10);

	IF(@Salary < 30000)
		BEGIN
			SET @SalaryLevel = 'Low'
		END
	ELSE IF(@Salary BETWEEN 30000 AND 50000)
		BEGIN
			SET @SalaryLevel = 'Average'
		END
	ELSE
		BEGIN
			SET @SalaryLevel = 'High'
		END

	RETURN @SalaryLevel
END
GO

SELECT	FirstName, 
		LastName, 
		Salary, 
		dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel
  FROM	Employees
 
 SELECT dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel,
		COUNT(*)
 FROM Employees
 GROUP BY dbo.udf_GetSalaryLevel(Salary)