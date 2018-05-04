--Random Junk


			
			
			
			
SELECT * FROM Employees

SELECT TOP (5) FirstName, LastName
FROM Employees





CREATE VIEW v_EmployeeNames AS
  SELECT [EmployeeID], [FirstName] ,[LastName]
  FROM [SoftUni].[dbo].[Employees]
SELECT * FROM v_EmployeeNames

CREATE PROCEDURE p_LoadEmployees AS
BEGIN
         SELECT [EmployeeID]
               ,[FirstName]
               ,[LastName]
               ,[Name] AS [DepartmentName]
           INTO [Test].[dbo].[EmployeeDepartments]
           FROM [SoftUni].[dbo].[Employees] AS e
LEFT OUTER JOIN [SoftUni].[dbo].[Departments] AS d
             ON e.DepartmentID = d.DepartentID
END
EXEC p_LoadEmployees


CREATE FUNCTION f_GetAge (@Birthday date)
RETURNS int
AS
  BEGIN
    DECLARE @Result int;
    SET @Result = DATEDIFF(YYYY, @Birthday, GETDATE());
    RETURN @Result
  END
SELECT [dbo].[f_GetAge]('2004/12/26')

CREATE TRIGGER t_DepartmentHistory ON [SoftUni].[dbo].[Departments]
FOR DELETE AS
BEGIN
  DECLARE @DepartmentID int;
  DECLARE @Name nvarchar(50);
  DECLARE @ManagerID int;

  SET @DepartmentID = (SELECT [DepartmentID] FROM DELETED);
  SET @Name = (SELECT [Name] FROM DELETED);
  SET @ManagerID = (SELECT [ManagerID] FROM DELETED);

  INSERT INTO [SoftUni].[dbo].[DepartmentHistory]
             ([DepartmentID], [Name], [ManagerID])
  VALUES (@DepartmentID, @Name, @ManagerID);

  PRINT 'Department with ID ' + CAST(@DepartmentID AS varchar(50))
        + ' has been recorded';
END


--Cheat Sheet on Queries 


--01. Data Types in SQL Server
Numeric
	bit (1-bit), integer (32-bit), bigint (64-bit)
	float, real, numeric(scale, precision)
	money – for money (precise) operations
Strings
	char(size) – fixed size string
	varchar(size) – variable size string
	nvarchar(size) – Unicode variable size string
	text / ntext – text data block (unlimited size)
Binary data
	binary(size) – fixed length sequence of bits
	varbinary(size) – a sequence of bits, 1-8000 bytes or max (2GB)
Date and time
	date – date in range 0001-01-01 through 9999-12-31
	datetime – date and time with precision of 1/300 sec
	smalldatetime – date and time (1-minute precision)

CREATE DATABASE Employees

CREATE TABLE People
(
  Id int NOT NULL,
  Email varchar(50) NOT NULL,
  FirstName varchar(50),
  LastName varchar(50)
)
--Primary Key
Id INT NOT NULL PRIMARY KEY
--Identity auto increment
Id INT IDENTITY PRIMARY KEY
--Unique constraint – no repeating values in entire table
Email VARCHAR(50) UNIQUE
--Default value – if not specified (otherwise set to NULL)
Balance DECIMAL(10,2) DEFAULT 0
--Value constraint
Kelvin DECIMAL(10,2) CHECK (Kelvin > 0)

--Altering Tables
ALTER TABLE Employees
ADD Salary DECIMAL(15, 2)

ALTER TABLE People
DROP COLUMN FullName

ALTER TABLE People
ALTER COLUMN Email VARCHAR(100)

--ALTER TABLE People
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)
Add primary key to existing column

--Add unique constraint
ALTER TABLE People
ADD CONSTRAINT uq_Email
UNIQUE (Email)

--Set default value
ALTER TABLE People
ADD DEFAULT 0
FOR Balance

--Add check constraint
ALTER TABLE InstrumentReadings
ADD CONSTRAINT PositiveValue
CHECK (Kelvin > 0)


--To delete all the entries in a table
TRUNCATE TABLE Employees

--To drop a table – delete data and structure
DROP TABLE Employees

--To drop entire database
DROP DATABASE AMS

--Removing constraint from column
--This includes primary keys, check constraints and unique fields
ALTER TABLE Employees
DROP CONSTRAINT pk_Id

--To remove default value (if not specified, revert to NULL)
ALTER TABLE Employees
ALTER COLUMN Clients
DROP DEFAULT

--02. CRUD
SELECT FirstName, LastName, JobTitle 
FROM Employees

SELECT * 
FROM Projects 
WHERE StartDate = '1/1/2006'

INSERT INTO Projects(Name, StartDate)
VALUES('Introduction to SQL Course', '1/1/2006')

UPDATE Projects
   SET EndDate = '8/31/2006'
 WHERE StartDate = '1/1/2006'

DELETE FROM Projects
WHERE StartDate = '1/1/2006'


--Concatenation Operator
--You can concatenate column names using the + operator
--String literals are enclosed in single quotes
--Column names containing special symbols use brackets
SELECT FirstName + ' ' + LastName AS [Full Name],
       EmployeeID AS [No.]
  FROM Employees

--Filtering the Selected Rows
--Use DISTINCT to eliminate duplicate results
SELECT DISTINCT DepartmentID
  FROM Employees
  
--Filter rows by specific conditions using the WHERE clause
SELECT LastName, DepartmentID 
  FROM Employees 
 WHERE DepartmentID = 1
--Other logical operators can be used for greater control
SELECT LastName, Salary FROM Employees
 WHERE Salary <= 20000
--Combine conditions using NOT, OR, AND and brackets
SELECT LastName FROM Employees
WHERE NOT (ManagerID = 3 OR ManagerID = 4)
--Using BETWEEN operator to specify a range:
SELECT LastName, Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 22000
--Using IN / NOT IN to specify a set of values:
SELECT FirstName, LastName, ManagerID FROM Employees
WHERE ManagerID IN (109, 3, 16)
--Comparing with NULL
SELECT LastName, ManagerId FROM Employees
WHERE ManagerId IS NULL | IS NOT NULL
--Sort rows with the ORDER BY clause
--ASC: ascending order, default
--DESC: descending order
SELECT LastName, HireDate
    FROM Employees
ORDER BY HireDate ASC | DESC

--Views
CREATE VIEW v_EmployeesByDepartment AS
SELECT FirstName + ' ' + LastName AS [Full Name],
       Salary
  FROM Employees
-- Call View
SELECT * FROM v_EmployeesByDepartment

--Inserting Data
--The SQL INSERT command
INSERT INTO Towns VALUES (33, 'Paris')
--Specify Column
INSERT INTO Projects (Name, StartDate)
     VALUES ('Reflective Jacket', GETDATE())
--Bulk data can be recorded in a single query, separated by comma
INSERT INTO EmployeesProjects
     VALUES (229, 1),
            (229, 2),
            (229, 3);
--Inserting rows into existing table:
INSERT INTO Projects (Name, StartDate)
     SELECT Name + ' Restructuring', GETDATE()
       FROM Departments
--Using existing records to create a new table:
SELECT CustomerID, FirstName, Email, Phone
  INTO CustomerContacts
  FROM Customers

 --Sequences are special object in SQL Server
--Similar to IDENTITY fields
--Returns an incrementing value every time it’s used
CREATE SEQUENCE seq_Customers_CustomerID
             AS INT
     START WITH 1
   INCREMENT BY 1
SELECT NEXT VALUE FOR seq_Customers_CustomerID 

--Deleting Data
--Deleting specific rows from a table
DELETE FROM Employees WHERE EmployeeID = 1
--Note: Don’t forget the WHERE clause!
--Delete all rows from a table (works faster than DELETE):
TRUNCATE TABLE Users


