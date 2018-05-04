--Check SubQuery and Operators
----Section 1. DDL (30 pts)

CREATE DATABASE WMS
GO
USE WMS
GO
--1. Database design

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(15) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) NOT NULL 
		CHECK (Status IN ('Pending', 'In Progress', 'Finished')) 
		DEFAULT 'Pending',
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId  INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE 
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY NOT NULL,	
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY NOT NULL,		
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY NOT NULL,		
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price DECIMAL (6,2) CHECK(Price > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0 NOT NULL,

)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL,
	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL,
	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

----Section 2. DML (10 pts)
--02. Insert
  --Notepad++
  --[\]t to [', ']
  --[\r\n] to ['),\r\n]

  INSERT INTO Clients(FirstName,LastName,Phone)
  VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp',  '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

  INSERT INTO Parts(SerialNumber, Description,Price,VendorId)
  VALUES
('WP8182119', 'Door Boot Seal', '117.86', '2'),
('W10780048', 'Suspension Rod', '42.81', '1'),
('W10841140', 'Silicone Adhesive ', '6.77', '4'),
('WPY055980', 'High Temperature Adhesive', '13.94', '3')
GO
--03. Update
UPDATE Jobs
SET Status = 'In Progress', MechanicId = 3
WHERE Status = 'Pending'
GO
--04. Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19
GO
----Section 3. Querying (45 pts)
--05. Clients by Name
SELECT
	FirstName,
	LastName,
	Phone
FROM Clients
ORDER BY lastname ASC, clientid 
GO
--06. Job Status
SELECT
	Status,
	IssueDate
FROM Jobs
WHERE Status <> 'Finished'
ORDER BY IssueDate ASC, JobId ASC
GO
--07. Mechanic Assignments
SELECT
	CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	j.[Status],
	j.IssueDate
FROM Mechanics AS m
INNER JOIN Jobs AS j
	ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, 
		j.IssueDate, 
		j.JobId
GO
--08. Current Clients
SELECT
	CONCAT(c.FirstName, ' ', c.LastName) AS Client,
	DATEDIFF(DAY, IssueDate, '04-24-2017') AS [Days going],
	j.Status
FROM Clients AS c
JOIN Jobs AS j
	ON j.ClientId	= c.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [Days going] DESC, j.ClientId
GO

--09. Mechanic Performance
SELECT 
	m.FirstName + ' ' + m.LastName AS Mechanic,
	AVG(DATEDIFF (DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j
	ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName
ORDER BY m.MechanicId
GO

--10. Hard Earners
SELECT TOP(3)
	m.FirstName + ' ' + m.LastName AS Mechanic,
	COUNT(*) AS Jobs
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.Status <> 'Finished'
GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName
HAVING COUNT(*) > 1
ORDER BY Jobs DESC, m.MechanicId ASC
GO
--11. Available Mechanics
SELECT 
	m.FirstName + ' ' + m.LastName AS Mechanic
FROM Mechanics AS m
WHERE M.MechanicId NOT IN
	(SELECT DISTINCT j.MechanicId
		FROM Jobs AS j
	WHERE j.Status <> 'Finished' AND j.MechanicId IS NOT NULL)
ORDER BY m.MechanicId
GO

--12. Parts Cost
SELECT
	ISNULL(SUM(p.Price * op.Quantity),0) AS [Parts Total]
FROM Parts AS p
JOIN OrderParts AS op 
	ON op.PartId = p.PartId
JOIN Orders AS o
	ON o.OrderId = op.OrderId
WHERE DATEDIFF(WEEK, o.IssueDate, '04-24-2017') <= 3
GO
--13. Past Expenses
SELECT 
	j.JobId,
	(
		SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
		FROM Parts AS p
		JOIN OrderParts AS op ON op.PartId = p.PartId
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN Jobs AS jo ON jo.JobId = o.JobId
		WHERE jo.JobId = j.JobId
	) AS Total
FROM Jobs AS j
WHERE j.Status = 'Finished'
ORDER BY Total DESC, j.JobId
GO

--14. Model Repair Time
SELECT 
	m.ModelId,
	m.Name,
	CAST(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS VARCHAR(10)) + ' days' AS [Average Service Time]
FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))

--15. Faultiest Model
SELECT TOP 1 WITH TIES
	m.Name,
	COUNT(*) AS [Times Serviced],
	(
		SELECT ISNULL(SUM(p.Price * op.Quantity), 0) 
		FROM Jobs AS j
		JOIN Orders AS o ON o.JobId = j.JobId
		JOIN OrderParts AS op ON op.OrderId = o.OrderId
		JOIN Parts AS p ON p.PartId = op.PartId
		WHERE j.ModelId = m.ModelId
	) AS [Parts Total]
FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId, M.Name
ORDER BY [Times Serviced] DESC
GO
--16. Missing Parts
SELECT p.PartId,
       p.Description,
       SUM(pn.Quantity) AS Required,
       AVG(p.StockQty) AS [In Stock],
       ISNULL(SUM(op.Quantity), 0) AS Ordered
  FROM Parts AS p
JOIN PartsNeeded pn ON pn.PartId = p.PartId
JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING AVG(p.StockQty) + ISNULL(SUM(op.Quantity), 0) < SUM(pn.Quantity)
ORDER BY p.PartId
GO
----Section 4. Programmability (15 pts)
--17. Cost of Order
CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(6,2)
AS
BEGIN
		DECLARE @TotalSum DECIMAL(6,2) = 
		(
		SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
		FROM Parts AS p
		JOIN OrderParts AS op ON op.PartId = p.PartId
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN Jobs AS jo ON jo.JobId = o.JobId
		WHERE jo.JobId = @JobId
		)
RETURN @TotalSum
END

SELECT dbo.udf_GetCost(3)

--18. Place Order
CREATE PROC usp_PlaceOrder @JobId INT, @SerialNumber VARCHAR(50), @Quantity INT
AS
BEGIN
    IF (@Quantity <= 0)
    BEGIN
        RAISERROR('Part quantity must be more than zero!', 16, 1);
        RETURN;
    END
    
    DECLARE @JobIdSelected INT = (SELECT JobId FROM Jobs WHERE JobId = @JobId)
    IF (@JobIdSelected IS NULL)
    BEGIN
        RAISERROR('Job not found!', 16, 1);
        RETURN;
    END

    DECLARE @JobStatus VARCHAR(11) = (SELECT Status FROM Jobs WHERE JobId = @JobId)

    IF (@JobStatus = 'Finished')
    BEGIN
        RAISERROR('This job is not active!', 16, 1);
        RETURN;
    END

    DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
    IF (@PartId IS NULL)
    BEGIN
        RAISERROR('Part not found!', 16, 1);
        RETURN;
    END

    DECLARE @OrderId INT = (SELECT o.OrderId FROM Orders AS o
    JOIN OrderParts AS op ON op.OrderId = o.OrderId
    JOIN Parts AS p ON p.PartId = op.PartId
    WHERE JobId = @JobId AND p.PartId = @PartId AND IssueDate IS NULL)

    -- Order does not exist -> create new order
    IF (@OrderId IS NULL)
    BEGIN
        INSERT INTO Orders (JobId, IssueDate) VALUES
        (@JobId, NULL)

        INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
        (IDENT_CURRENT('Orders'), @PartId, @Quantity)
    END
    ELSE
    BEGIN
        DECLARE @PartExistsInOrder INT = (SELECT @@ROWCOUNT FROM OrderParts
                                          WHERE OrderId = @OrderId AND PartId = @PartId)
        
        IF (@PartExistsInOrder IS NULL)
        BEGIN
            -- Order exists, part does not exist in it -> add part to order      
            INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
            (@OrderId, @PartId, @Quantity)
        END
        ELSE
        BEGIN
            -- Order exists, part exists -> increase part quantity in order
            UPDATE OrderParts
            SET Quantity += @Quantity
            WHERE OrderId = @OrderId AND PartId = @PartId
        END
    END
END

--19. Detect Delivery
CREATE TRIGGER tr_OrderDelivered ON Orders
AFTER UPDATE
AS
BEGIN
    DECLARE @OldStatus INT = (SELECT Delivered FROM deleted)
    DECLARE @NewStatus INT = (SELECT Delivered FROM inserted)

    IF (@OldStatus = 0 AND @NewStatus = 1)
    BEGIN
        UPDATE Parts
        SET StockQty += op.Quantity
        FROM Parts AS p
        JOIN OrderParts op ON op.PartId = p.PartId
        JOIN Orders o ON o.OrderId = op.OrderId
        JOIN inserted AS i ON i.OrderId = o.OrderId
        JOIN deleted AS d ON d.OrderId = o.OrderId
        WHERE d.Delivered = 0 AND i.Delivered = 1
    END
END

BEGIN TRAN
    UPDATE Orders
    SET Delivered = 1
    WHERE OrderId = 21
ROLLBACK

----Section 5. Bonus (10 pts)
--20. Vendor Preference
WITH CTE_VendorPreference
AS
(
    SELECT m.MechanicId, v.VendorId, SUM(op.Quantity) AS ItemsFromVendor FROM Mechanics AS m
    JOIN Jobs AS j ON j.MechanicId = m.MechanicId
    JOIN Orders AS o ON o.JobId = j.JobId
    JOIN OrderParts op ON op.OrderId = o.OrderId
    JOIN Parts AS p ON p.PartId = op.PartId
    JOIN Vendors v ON v.VendorId = p.VendorId
    GROUP BY m.MechanicId, v.VendorId
)

SELECT m.FirstName + ' ' + LastName AS Mechanic,
       v.Name AS Vendor,
       c.ItemsFromVendor AS Parts,
CAST(CAST(CAST(ItemsFromVendor AS DECIMAL(6, 2)) / (SELECT SUM(ItemsFromVendor) FROM CTE_VendorPreference WHERE MechanicId = c.MechanicId) * 100 AS INT) AS VARCHAR(20)) + '%' AS Preference
FROM CTE_VendorPreference AS c
JOIN Mechanics m ON m.MechanicId = c.MechanicId
JOIN Vendors v ON v.VendorId = c.VendorId
ORDER BY Mechanic, Parts DESC, Vendor


