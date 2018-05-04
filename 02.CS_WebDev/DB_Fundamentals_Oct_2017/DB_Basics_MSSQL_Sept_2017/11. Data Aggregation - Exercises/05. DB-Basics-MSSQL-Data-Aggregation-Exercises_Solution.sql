--01. Records Count
USE Gringotts
GO

SELECT COUNT (*) AS Count
FROM WizzardDeposits

--02. Longest Magic Wand
SELECT MAX(MagicWandSize) as [LongestMagicWand]
FROM WizzardDeposits

--03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup,
	MAX(MagicWandSize) as [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

--04. Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--05. Deposits Sum
SELECT DepositGroup,
		SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--06. Deposits Sum for Ollivander Family
SELECT DepositGroup,
		SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--07. Deposits Filter
SELECT DepositGroup,
		SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--08. Deposit Charge
SELECT DepositGroup,
		MagicWandCreator,
		MIN (DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--09. Age Groups
SELECT
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
	END AS AgeGroup,
	COUNT (*) AS WizzardCount
FROM WizzardDeposits
GROUP BY
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age >= 61 THEN '[61+]'
	END

--10. Magic Size Groups
SELECT LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter ASC

--11. Average Interest 1
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985.01.01'
GROUP BY DepositGroup, IsDepositExpired 
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12. Rich Wizard, Poor Wizard
SELECT SUM(DepositAmount - GuestDeposit) AS SumDifference
FROM (SELECT DepositAmount,
	LEAD(DepositAmount) OVER(ORDER BY(Id)) AS GuestDeposit
	FROM WizzardDeposits) AS WizzardDeposits


--13. Departments Total Salaries
USE SoftUni
GO

SELECT DepartmentID, SUM(Salary) AS TotalSalary 
FROM Employees
GROUP BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
	AND HireDate > '2000.01.01'
GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT * INTO EmployeesII FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesII
WHERE ManagerID = 42

UPDATE EmployeesII
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID ,AVG(Salary) AS AverageSalary
FROM EmployeesII
GROUP BY DepartmentID

DROP TABLE EmployeesII

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(Salary) AS Count 
FROM Employees
WHERE ManagerID IS NULL

--18. 3rd Highest Salary
SELECT DepartmentID, Salary
FROM	(SELECT DepartmentID, 
		MAX(Salary) AS Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
		FROM Employees
		GROUP BY DepartmentID, Salary
		) AS RankedSalaries
WHERE Rank = 3
--19. Salary Challenge
SELECT TOP 10 e1.FirstName, e1.LastName, e1.DepartmentID
FROM Employees AS e1
WHERE Salary >
	(SELECT AVG(Salary)
	FROM Employees AS e2
	WHERE e2.DepartmentID = e1.DepartmentID
	GROUP BY DepartmentID)
