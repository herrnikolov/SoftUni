CREATE DATABASE ReportService

USE ReportService

--1. DDL

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY,
Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username NVARCHAR(30) UNIQUE NOT NULL,
Password NVARCHAR(50) NOT NULL,
Name NVARCHAR(50),
Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
BirthDate DATETIME,
Age INT,
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
BirthDate DATETIME,
Age INT,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
Description NVARCHAR(200),
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2. Insert

INSERT INTO Employees(FirstName,LastName,Gender,BirthDate,DepartmentId) VALUES
('Marlo','O’Malley','M','9/21/1958',1),
('Niki','Stanaghan','F','11/26/1969',4),
('Ayrton','Senna','M','03/21/1960',9),
('Ronnie','Peterson','M','02/14/1944',9),
('Giovanna','Amati','F','07/20/1959',5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(1,1,'04/13/2017',NULL,'Stuck Road on Str.133',6,2),
(6,3,'09/05/2015','12/06/2015','Charity trail running',3,5),
(14,2,'09/07/2015',NULL,'Falling bricks on Str.58',5,2),
(4,	3,'7/03/2017','07/06/2017','Cut off streetlight on Str.11',1,1)

--3. Update

UPDATE Reports
SET StatusId=2
WHERE StatusId=1
AND CategoryId=4

--4. Delete (all reports with status blocked

DELETE FROM Reports
WHERE StatusId IN (SELECT Id FROM Status WHERE Label='blocked')

--5. Users by age

SELECT Username,
	   Age
  FROM Users
ORDER BY Age, Username DESC

--6. Unassigned Reports

SELECT Description,
	   OpenDate
  FROM Reports
 WHERE EmployeeId IS NULL
ORDER BY OpenDate, EmployeeId DESC

--7.	Employees & Reports


SELECT e.FirstName,
	   e.LastName,
	   r.Description,
	   FORMAT(r.OpenDate,'yyyy-MM-dd') AS OpenDate
  FROM Employees AS e
  JOIN Reports as R
    ON r.EmployeeId=e.Id
 WHERE e.Id IN (SELECT EmployeeId FROM Reports WHERE EmployeeId IS NOT NULL)
 ORDER BY e.Id, r.OpenDate, r.Id

 --08. Most Reported Category 

 SELECT c.Name,
        COUNT(r.Id) AS ReportsNumber
   FROM Categories AS c
   JOIN Reports AS r
     ON r.CategoryId=c.Id
GROUP BY c.Name
Order BY ReportsNumber DESC, c.Name

--09. Employees in Category

SELECT c.Name AS CategoryName,
       COUNT(*) AS EmployeesNumber
  FROM Categories AS c
  JOIN Departments AS d
    ON d.Id=c.DepartmentId
  JOIN Employees AS e
   ON e.DepartmentId=d.Id
GROUP BY c.Name
ORDER BY c.Name

--10. Users per Employee 

SELECT CONCAT(em.FirstName,' ',em.LastName) AS Name,
       (SELECT ISNULL(COUNT(DISTINCT r.UserID),0) AS UsersNumbers
			FROM Employees AS e
			JOIN Reports AS r
			ON r.EmployeeId=e.Id
		 WHERE e.Id=em.Id) AS UsersNumbers
	FROM Employees AS em
ORDER BY UsersNumbers DESC, Name

--11. Emergency Patrol 

SELECT r.OpenDate,
	   r.Description,
	   u.Email
  FROM Users AS u
  JOIN Reports AS r
    ON r.UserId=u.Id
  JOIN Categories AS c
    ON c.Id=r.CategoryId
  JOIN Departments AS d
    ON d.Id=c.DepartmentId
 WHERE r.CloseDate IS NULL 
   AND (LEN(r.Description)>20 AND r.Description LIKE '%str%')
   AND d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY r.OpenDate,u.Email,u.Id

--12. Birthday Report -66

SELECT c.Name AS CategoryName
  FROM Categories AS c
  JOIN Reports AS r
    ON r.CategoryId=c.Id
  JOIN Users AS u
    ON u.Id=r.UserId
 WHERE DATEPART(DAY,r.OpenDate)=DATEPART(DAY,u.BirthDate)
   AND DATEPART(MONTH,r.OpenDate)=DATEPART(MONTH,u.BirthDate)
GROUP BY c.Name

--13. Numbers Coincidence-71

SELECT DISTINCT u.Username
  FROM Users AS u
  JOIN Reports AS r
    ON r.UserId=u.Id
  JOIN Categories AS c
    ON c.DepartmentId=r.CategoryId
 WHERE (u.Username LIKE '[0-9]%' AND CAST(r.CategoryId AS CHAR)=SUBSTRING(u.Username,1,1))
		OR (u.Username LIKE '%[0-9]' AND CAST(r.CategoryId AS CHAR)=SUBSTRING(u.Username,LEN(u.UserName),1))
ORDER BY u.Username

--14. Open/Closed Statistics - 75

 SELECT Name,
        CAST(Closed AS VARCHAR(50)) + '/' + CAST(Opened AS VARCHAR) AS [Closed/Open Reports]
  FROM (SELECT CONCAT(e.FirstName,' ',e.LastName) AS Name,
        e.Id,
	   COUNT(r.CloseDate) AS Closed,
       COUNT(r.OpenDate) AS Opened
  FROM Employees AS e
  JOIN Reports AS r
    ON r.EmployeeId=e.Id
 WHERE DATEPART(YEAR,r.OpenDate)=2016
 OR ISNULL(DATEPART(YEAR,r.CloseDate),0)=2016
 GROUP BY CONCAT(e.FirstName,' ',e.LastName), e.Id) AS x
 JOIN Employees AS em
   ON em.Id=x.Id
ORDER BY Name, em.Id

--15. Average Closing Time -80

SELECT DepartmentName,
       (CASE 
			WHEN AverageDuration IS NULL THEN 'no info'
			ELSE AverageDuration
			END) AS AverageDuration
FROM (SELECT DepartmentName,
       CAST(AverageDuration AS NVARCHAR(MAX)) AS AverageDuration
  FROM (SELECT d.Name AS DepartmentName,
       AVG(DATEDIFF(DAY,r.OpenDate,r.CloseDate)) AS AverageDuration
  FROM Departments AS d
  JOIN Categories AS  c
    ON c.DepartmentId=d.Id
  JOIN Reports AS r
    ON r.CategoryId=c.Id
GROUP BY d.Name) AS x) AS y
ORDER BY DepartmentName

--16. Favorite Categories  -- ne e reshena


select * from Departments
select * from Categories
select * from Reports
select * from users

SELECT d.Name AS DepartmentName,
       c.Name AS CategoryName,
	   COUNT(c.Id) AS AmountInNumbers
  FROM Departments as d
  JOIN Categories as c
    ON c.DepartmentId=d.Id
JOIN Reports as r
    on r.CategoryId=c.Id
GROUP BY d.Name,c.Name
ORDER BY d.Name


SELECT DepartmentName,
       AmountInNumbers,
	   count(AmountInNumbers)*100/CAST(SUM(Count(AmountInNumbers)) over (Partition by DepartmentName) as float) As Percentage
  FROM (SELECT d.Name AS DepartmentName,
       c.Name AS CategoryName,
	   COUNT(c.Id) AS AmountInNumbers
  FROM Departments as d
  JOIN Categories as c
    ON c.DepartmentId=d.Id
JOIN Reports as r
    on r.CategoryId=c.Id
GROUP BY d.Name,c.Name
) as x
GROUP BY DepartmentName, AmountInNumbers



	
--17.Employee's Load -- 84

CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS 
BEGIN
     DECLARE @sum INT
	 SET @sum=(SELECT COUNT(*)
	 FROM Reports
	 WHERE EmployeeId=@employeeId
	 AND StatusId=@statusId)

	 RETURN @sum
END

--18. Assign Employee --89

CREATE PROC usp_AssignEmployeeToReport @employeeId INT, @reportId INT
AS 
BEGIN

DECLARE @employeeDepartment INT
	SET @employeeDepartment=(select DepartmentId from Employees where Id=@employeeId)

	DECLARE @categoryDepartment INT
	DECLARE @departmentId INT
	SET @departmentId=(select CategoryId FROM Reports where Id=@reportId)
	SET @categoryDepartment=(select DepartmentId from Categories where Id=@departmentId)

	BEGIN TRANSACTION

	UPDATE Reports
	SET EmployeeId=@employeeId
	WHERE Id=@reportId

	IF(@categoryDepartment<>@employeeDepartment)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
		ROLLBACK
	END
	ELSE
	COMMIT
END


--19. Close Reports--  94

CREATE TRIGGER tr_CloseReports
ON Reports
AFTER UPDATE
AS
BEGIN
	 UPDATE Reports
	 SET StatusId=3
	 FROM Reports AS r
	 JOIN deleted as d
	   on d.Id=r.id
	 JOIN inserted as i
	   ON i.Id=d.Id
	 WHERE d.CloseDate IS NULL
	 AND i.CloseDate IS NOT NULL
END

--20. Categories Revision

select * from Categories
select * from Reports
select * from Status

SELECT c.Name AS CategoryName,
	   COUNT(r.Id) AS ReportsNumber
  FROM Categories as c
  JOIN Reports AS  r
    ON r.CategoryId=c.Id
 WHERE r.StatusId IN (1,2)
GROUP BY c.Name


SELECT x.CategoryName,
       x.Waiting,
	   ISNULL(y.InProgress,0) AS InProgress,
	   (CASE
	        WHEN x.Waiting>y.InProgress THEN 'waiting'
			WHEN x.Waiting<y.InProgress THEN 'in progress'
			WHEN x.Waiting=y.InProgress THEN 'equal'
			END) AS MainStatus
 FROM (SELECT c.Name AS CategoryName,
	   COUNT(r.Id) AS Waiting
  FROM Categories as c
  JOIN Reports AS  r
    ON r.CategoryId=c.Id
 WHERE r.StatusId=1
GROUP BY c.Name) AS x
LEFT JOIN (SELECT c.Name AS CategoryName,
	   COUNT(r.Id) AS InProgress
  FROM Categories as c
  JOIN Reports AS  r
    ON r.CategoryId=c.Id
 WHERE r.StatusId=2 
GROUP BY c.Name) as y
ON x.CategoryName=y.CategoryName



SELECT c.Name AS CategoryName,
	   COUNT(r.Id) AS ReportsNumber
  FROM Categories as c
  JOIN Reports AS  r
    ON r.CategoryId=c.Id
 WHERE r.StatusId IN (1,2)
GROUP BY c.Name

https://github.com/gaydov/Softuni-DB-Basics/tree/master/Exam-22nd-Oct-2017/Exam-22nd-Oct-2017

16
SELECT 
[Department Name],
[Category Name],
CAST(ROUND(CAST(Cnt AS decimal(16,4))/CntMax*100,0) AS INT) AS Percentage
 FROM(
SELECT d.Name as [Department Name],
c.Name AS [Category Name],
COUNT(*) AS Cnt,
(SELECT COUNT(*) FROM Reports  as r1 JOIN Categories 
as c1 ON c1.Id = r1.CategoryId  WHERE c1.DepartmentId=c.DepartmentId) AS CntMax
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
JOIN Departments AS d
ON d.Id = c.DepartmentId
GROUP BY c.DepartmentId,d.Name, c.Name 
) T
ORDER BY [Department Name],
[Category Name],
Percentage