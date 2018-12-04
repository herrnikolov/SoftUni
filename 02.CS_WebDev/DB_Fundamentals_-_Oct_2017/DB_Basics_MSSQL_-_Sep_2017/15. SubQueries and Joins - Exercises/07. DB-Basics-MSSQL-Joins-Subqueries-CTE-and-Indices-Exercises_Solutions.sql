--01. Employee Address
USE SoftUni
GO

SELECT TOP (5)
	e.EmployeeID,
	e.JobTitle,
	a.AddressId,
	a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
	ON a.AddressID = e.AddressID
ORDER BY AddressID ASC

--02. Addresses with Towns
SELECT TOP (50)
	e.FirstName,
	e.LastName,
	t.Name AS [Town],
	a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
	ON a.AddressID = e.AddressID
INNER JOIN Towns AS t
	ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

--03. Sales Employee
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS DepartmentName
FROM Employees AS e
INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

--04. Employee Departments
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS DepartmentName
FROM Employees AS e
INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
WHERE e.Salary >= 15000
ORDER BY e.DepartmentID ASC

--05. Employees Without Project
SELECT TOP(3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
WHERE EmployeeID NOT IN
	(SELECT DISTINCT EmployeeID
	 FROM EmployeesProjects
	)
ORDER BY EmployeeID ASC

--06. Employees Hired After
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
FROM Employees AS e
INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1/1/1999'
AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

--07. Employees With Project
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '20020813'
	AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

--08. Employee 24
SELECT 
	e.EmployeeID,
	e.FirstName,
	CASE
		WHEN p.StartDate > '20050101' 
			THEN NULL
		ELSE p.[Name]
	END
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--09. Employee Manager
SELECT
	e.EmployeeID,
	e.FirstName,
	e2.ManagerID,
	e2.FirstName AS ManagerName
FROM Employees AS e
INNER JOIN Employees AS e2
	ON e2.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY EmployeeID ASC

--10. Employee Summary
SELECT TOP 50
	e.EmployeeID, 
	e.FirstName + ' ' + e.LastName, 
	m.FirstName+ ' ' + m.LastName,
	d.[Name]
FROM Employees AS e
INNER JOIN Employees AS m 
	ON m.EmployeeID = e.ManagerID
INNER JOIN Departments AS d 
	ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID ASC

--11. Min Average Salary
SELECT 
	AVG(e.Salary) 
FROM Employees AS e
GROUP BY e.DepartmentID
HAVING AVG(e.Salary) = 
(
	SELECT MIN(salaries.Salary) 
	FROM
		(SELECT AVG(e.Salary) AS Salary 
		FROM Employees AS e
		GROUP BY e.DepartmentID
		) AS salaries
)

--12. Highest Peak in Bulgaria
USE Geography
GO

SELECT 
	c.CountryCode, 
	m.MountainRange, 
	p.PeakName, 
	p.Elevation 
FROM Countries AS c
INNER JOIN MountainsCountries AS mc 
	ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m 
	ON m.Id = mc.MountainId
INNER JOIN Peaks AS p 
	ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria' 
	AND p.Elevation > 2835
ORDER BY Elevation DESC

--13. Count Mointain Ranges
SELECT 
	c.CountryCode, 
	COUNT(mc.MountainId) 
FROM Countries AS c
INNER JOIN MountainsCountries AS mc 
ON mc.CountryCode = c. CountryCode
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode

--14. Countries With or Without Rivers
SELECT TOP 5 
	c.CountryName, 
	r.RiverName 
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr 
	ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r 
	ON r.Id = cr.RiverId
LEFT JOIN Continents AS con 
	ON con.ContinentCode = c.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT 
	cu.ContinentCode, 
	cu.CurrencyCode, 
	cu.Usages 
FROM
(
	SELECT 
		con.ContinentCode, 
		cu.CurrencyCode, 
		COUNT(cu.CurrencyCode) AS Usages,
		DENSE_RANK() 
			OVER(PARTITION BY(con.ContinentCode) 
		ORDER BY COUNT(cu.CurrencyCode) DESC) AS Rank
	FROM Continents AS con
INNER JOIN Countries AS c 
	ON c.ContinentCode = con.ContinentCode
INNER JOIN Currencies AS cu 
	ON cu.CurrencyCode = c.CurrencyCode
GROUP BY con.ContinentCode, cu.CurrencyCode
HAVING COUNT(cu.CurrencyCode) > 1
) AS cu
WHERE cu.Rank = 1

--16. Countries Without any Mountains
SELECT 
	COUNT(CountryCode) 
FROM Countries
WHERE CountryCode NOT IN 
	(SELECT 
		DISTINCT CountryCode 
	FROM MountainsCountries)

--17. Highest Peak and Longest River by Country
SELECT TOP 5 
	c.CountryName, 
	MAX(p.Elevation) AS MaxPeakElevation, 
	MAX(r.Length) AS MaxRiverLength 
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc 
	ON mc.CountryCode = c.CountryCode
LEFT JOIN Peaks AS p 
	ON p.MountainId = mc.MountainId
LEFT JOIN CountriesRivers AS cr 
	ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r 
	ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY MaxPeakElevation DESC, MaxRiverLength DESC

--18. *Highest Peak Name and Elevation by Country
SELECT TOP 5
	pk.CountryName AS Country,  
CASE
	WHEN pk.PeakName IS NULL THEN '(no highest peak)'
	ELSE pk.PeakName
END AS [Highest Peak Name], 
CASE
	WHEN pk.Elevation IS NULL THEN 0
	ELSE pk.Elevation
END AS [Highest Peak Elevation],
CASE
	WHEN pk.MountainRange IS NULL THEN '(no mountain)'
	ELSE pk.MountainRange
END AS MountainRange FROM(
	SELECT 
		c.CountryName, 
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS Rank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
) AS pk
WHERE pk.Rank = 1
ORDER BY Country, [Highest Peak Elevation]
