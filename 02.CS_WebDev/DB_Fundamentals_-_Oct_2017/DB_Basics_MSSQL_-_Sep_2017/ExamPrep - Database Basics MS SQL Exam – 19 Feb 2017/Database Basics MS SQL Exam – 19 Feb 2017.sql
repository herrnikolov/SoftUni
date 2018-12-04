-- Check Constraints
-- Decima isted of Money on exam
----Section 1. DDL (25 pts)
CREATE DATABASE Bakery
GO
USE Bakery
GO

--1. Database design
CREATE TABLE Countries
(
	Id INT IDENTITY,
	--Id INT PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) UNIQUE,
	CONSTRAINT PK_Countries PRIMARY KEY (Id)
)

CREATE TABLE Products
(
	Id INT IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	Description NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price MONEY CHECK(Price > 0),
	CONSTRAINT PK_PRODUCTS PRIMARY KEY (Id)
)
CREATE TABLE Customers
(
	Id INT IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK (Gender IN ('M', 'F')),
	Age INT,
	PhoneNumber CHAR(10) CHECK(ISNUMERIC(PhoneNumber) = 1),
	CountryId INT,
--  CountryId INT FOREIGN KEY REFERENCES Countries(Id )
	CONSTRAINT PK_Customers PRIMARY KEY (Id),
	CONSTRAINT FK_Customers_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
	
)
CREATE TABLE Feedbacks
(
	Id int IDENTITY, 
	[Description] NVARCHAR(255),
	Rate DECIMAL(4, 2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT, 
	CustomerId INT,
	CONSTRAINT PK_Feedbacks PRIMARY KEY (Id),
	CONSTRAINT FK_Feedbacks_Products FOREIGN KEY (ProductId) REFERENCES Products(Id),  
	CONSTRAINT FK_Feedbacks_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
)
CREATE TABLE Distributors
(
	Id INT IDENTITY,
	Name NVARCHAR(25) UNIQUE, 
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT,
	CONSTRAINT PK_Distributors PRIMARY KEY (Id),
	CONSTRAINT FK_Distributors_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)
CREATE TABLE Ingredients
(
	Id INT IDENTITY,
	Name NVARCHAR(30),
	[Description] NVARCHAR(200),
	OriginCountryId INT, 
	DistributorId INT,
	CONSTRAINT PK_Ingredients PRIMARY KEY (Id),
	CONSTRAINT FK_Ingredients_Countries FOREIGN KEY (OriginCountryId) REFERENCES Countries(Id),  
	CONSTRAINT FK_Ingredients_Distributors FOREIGN KEY (DistributorId) REFERENCES Distributors(Id)
)
CREATE TABLE ProductsIngredients
(
	ProductId INT, 
	IngredientId INT,
	CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId),
	CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY (ProductId) REFERENCES Products(Id),  
	CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY (IngredientId) REFERENCES Ingredients(Id)
)
GO

----Section 2. DML (15 pts)
--02. Insert
INSERT INTO Distributors([Name], CountryId, AddressText,Summary)
VALUES
('Deloitte & Touche',2,'6 Arch St #9757','Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')
GO
INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)
GO
--03. Update
UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf','Paprika','Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04.Delete
DELETE 
FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5;

----Section 3. Querying (40 pts)
--05.Products by Price
SELECT [Name], 
		Price, 
		Description
FROM	Products
ORDER BY Price DESC, 
		[Name] ASC

--06.Ingredients
SELECT [Name],
	Description,
	OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1,10,20)
ORDER BY Id ASC

--07. Ingredients from Bulgaria and Greece
SELECT TOP(15)
	I.Name,
	I.Description,
	C.Name AS [CountryName]
FROM Ingredients as I
JOIN Countries as C
ON C.Id = I.OriginCountryId
WHERE C.Name IN ('Greece', 'Bulgaria')
ORDER BY I.Name, CountryName

--08. Best Rated Products
SELECT P.Name, p.Description,BestRated.AverageRate, BestRated.FeedbackAmount
FROM	
		(
		SELECT TOP (10)
			ProductId,
			AVG(Rate) AS AverageRate,
			COUNT(Id) AS FeedbackAmount
		FROM Feedbacks
		GROUP BY ProductId
		ORDER BY AverageRate DESC, FeedbackAmount DESC
		) 
		AS BestRated
JOIN Products AS p
	ON P.Id = BestRated.ProductId

--09. Negative Feedback
SELECT f.ProductId,
		f.Rate,
		f.[Description],
		f.CustomerId,
		c.Age,
		c.Gender
FROM Feedbacks AS f
JOIN Customers AS c
	ON C.Id = F.CustomerId
WHERE f.Rate < 5.0
ORDER BY f.ProductId  DESC, f.Rate ASC

--10.	Customers without Feedback
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	c.PhoneNumber, 
	c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f 
	ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id

--OR with sub query
--WHERE Id NOT IN(SELECT CustomerId FROM Feedbacks)
--Insted of the LEFT JOIN and the WHERE clause

--11. Honorable Mentions
SELECT 
  f.ProductId, 
  CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
  ISNULL(f.Description, '') AS FeedbackDescription
FROM Feedbacks AS f
JOIN (
  SELECT CustomerId
  FROM Feedbacks
  GROUP BY CustomerId
  HAVING COUNT(Id) >= 3
) AS topCust ON f.CustomerId = topCust.CustomerId
JOIN Customers AS c ON c.Id = topCust.CustomerId
ORDER BY f.ProductId, CustomerName, f.Id

--12. Customers by Criteria
SELECT c.FirstName,
	c.Age,
	c.PhoneNumber
FROM Customers AS c
JOIN Countries AS co
	ON co.Id = c.CountryId
WHERE (Age >= 21 AND FirstName LIKE '%AN%')
	OR(PhoneNumber LIKE '%38' AND CO.Name <> 'Greece')
ORDER BY c.FirstName ASC, c.Age DESC

--13. Middle Range Distributors
SELECT 
  d.Name AS DistributorName, 
  i.Name AS IngredientName,
  p.Name AS ProductName,
  ratedProducts.AverageRate
FROM 
(
  SELECT ProductId, 
	AVG(Rate) AS AverageRate
  FROM Feedbacks 
  GROUP BY ProductId
  HAVING AVG(Rate) BETWEEN 5 AND 8
) AS ratedProducts
JOIN Products AS p ON p.Id = ratedProducts.ProductId
JOIN ProductsIngredients AS pi ON pi.ProductId = ratedProducts.ProductId
JOIN Ingredients AS i ON i.Id = pi.IngredientId
JOIN Distributors AS d ON d.Id = i.DistributorId
ORDER BY DistributorName, IngredientName, ProductName

--14. The Most Positive Country
SELECT TOP(1) WITH TIES
	co.Name AS CountryName,
	AVG(f.Rate) AS FeedbackRate
FROM Feedbacks AS f
JOIN Customers AS c
	ON c.Id = f.CustomerId
JOIN Countries AS co
	ON CO.Id = c.CountryId
GROUP BY co.Name
ORDER BY FeedbackRate DESC

--15. Country Representative
SELECT CountryName, 
	DistributorName
FROM 
(
  SELECT 
    co.Name AS CountryName, d.Name AS DistributorName, 
    COUNT(i.Id) AS IngredientsCount,
    DENSE_RANK() OVER (PARTITION BY co.Name ORDER BY COUNT(i.Id) DESC) AS DistributorRank 
	-- ranking for most active distributor by country (delivering max IngredientsCount) 
  FROM Countries AS co
  JOIN Distributors AS d ON d.CountryId = co.Id
  JOIN Ingredients AS i ON i.DistributorId = d.Id
  GROUP BY d.Name, co.Name
) AS CountryDistributorStats
WHERE DistributorRank = 1
ORDER BY CountryName, DistributorName

--16. Customers With Countries
CREATE VIEW v_UserWithCountries 
AS
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	c.Age,
	c.Gender,
	co.Name AS CountryName
FROM Customers AS c
JOIN Countries AS co
	on co.Id = c.CountryId
GO
SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age
GO

--17. Feedback by Product Name
CREATE FUNCTION udf_GetRating (@productName NVARCHAR(25))
RETURNS VARCHAR(20)
AS
BEGIN
	DECLARE @rating DECIMAL (4,2) =
	(
		SELECT AVG(f.Rate)
		FROM Feedbacks AS f
		LEFT JOIN Products AS P 
			ON f.ProductId = p.Id
		WHERE P.Name = @productName
	)
	DECLARE @descrRating VARCHAR(20)
	IF(@rating <5)
		SET @descrRating = 'Bad';
	ELSE IF (@rating BETWEEN 5 AND 8) 
		SET @descrRating = 'Average';
	ELSE IF (@rating > 8)
		SET @descrRating = 'Good';
	ELSE IF (@rating IS NULL)
		SET @descrRating = 'No rating';
	RETURN @descrRating;
END
GO

SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id
 GO

--18. Send Feedback
CREATE PROCEDURE usp_SendFeedback (@customerId int, @productId int, @rate decimal(4,2), @description nvarchar(255))
AS
BEGIN
  BEGIN TRANSACTION
  INSERT INTO Feedbacks (Description, Rate, ProductId, CustomerId)
  VALUES (@description, @rate, @productId, @customerId)

  IF((SELECT COUNT(Id) FROM Feedbacks WHERE CustomerId = @customerId) >= 3)
    BEGIN
      ROLLBACK;
      RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1);
    END
  ELSE COMMIT;
END

--testing
EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';

SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;

--19. Delete Products
CREATE TRIGGER tr_DeleteProductRelations ON Products
INSTEAD OF DELETE
AS
BEGIN
  DELETE FROM ProductsIngredients
  WHERE ProductId = (SELECT Id FROM deleted)

  DELETE FROM Feedbacks
  WHERE ProductId = (SELECT Id FROM deleted)

  DELETE FROM Products 
  WHERE Id = (SELECT Id FROM deleted)
END

--testing
DELETE FROM Products WHERE Id = 7

--20. Products by One Distributor
SELECT 
  Result.ProductName, Result.ProductAverageRate, 
  Result.DistributorName, Result.DistributorCountry
FROM (
  SELECT 
    p.Name AS ProductName, AVG(f.Rate) AS ProductAverageRate,
    d.Name AS DistributorName, c.Name AS DistributorCountry
  FROM (
    SELECT p.Id
    FROM Products AS p
    JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
    JOIN Ingredients AS i ON pi.IngredientId = i.Id
    JOIN Distributors AS d ON i.DistributorId = d.Id
    GROUP BY p.Id
    HAVING COUNT(DISTINCT d.Id) = 1
  ) AS SingleDistProducts
  JOIN Products AS p ON p.Id = SingleDistProducts.Id
  JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
  JOIN Ingredients AS i ON pi.IngredientId = i.Id
  JOIN Distributors AS d ON d.Id = i.DistributorId
  JOIN Countries AS c ON d.CountryId = c.Id
  JOIN Feedbacks AS f ON p.Id = f.ProductId
  GROUP BY p.Name, d.Name, c.Name
) AS Result
JOIN Products p1 on p1.Name = Result.ProductName
ORDER BY p1.Id