--01. Create Table Logs
USE Bank
GO

CREATE TABLE Logs(
	LogId INT IDENTITY NOT NULL,
	AccountId INT NOT NULL,
	OldSum MONEY,
	NewSum MONEY
	);

IF OBJECT_ID ('t_Account') IS NOT NULL
	DROP TRIGGER t_Account
GO

CREATE TRIGGER t_Account ON Accounts AFTER UPDATE
AS
BEGIN
		DECLARE @accountId INT = (SELECT Id FROM inserted);
		DECLARE @oldSum MONEY = (SELECT Balance FROM deleted);
		DECLARE @newSum MONEY = (SELECT Balance FROM inserted);
		INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES (@accountId, @oldSum, @newSum);
END

GO
--02. Create Table Emails
CREATE TABLE NotificationEmails
		(
		Id INT IDENTITY NOT NULL,
		Recipient INT NOT NULL,
		Subject VARCHAR(50),
		Body VARCHAR(300)
		CONSTRAINT PK_NotificationEmails PRIMARY KEY (Id)
		)
GO

--03. Deposit Money
CREATE PROCEDURE usp_DepositMoney @account INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;
	
	UPDATE Accounts SET Balance = Balance + @moneyAmount
	WHERE Id = @account;
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid account!', 16, 1);
		RETURN;
	END;  

	COMMIT;
END
GO
--04. Withdraw Money Procedure
CREATE PROCEDURE usp_WithdrawMoney @account INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;
	
	UPDATE Accounts SET Balance = Balance - @moneyAmount
	WHERE Id = @account;
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK;
		RAISERROR('Invalid account!', 16, 1);
		RETURN;
	END;  

	COMMIT;
END
GO
--05. Money Transfer
CREATE PROCEDURE usp_TransferMoney @fromAccount INT, @toAccount INT, @moneyAmount MONEY
AS
BEGIN
	BEGIN TRANSACTION;

	IF @moneyAmount < 0
	BEGIN
		ROLLBACK;
		RAISERROR('Money amount cannot be negative', 16, 1);
		RETURN;
	END;

	EXEC dbo.usp_WithdrawMoney @fromAccount, @moneyAmount;

	EXEC dbo.usp_DepositMoney @toAccount, @moneyAmount;

	COMMIT;
END
GO
--07. *Massive Shopping
BEGIN TRANSACTION
DECLARE @sum1 MONEY = (SELECT SUM(i.Price)
						FROM Items i
						WHERE MinLevel BETWEEN 11 AND 12)

IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum1 --hardcoding for the win
ROLLBACK
ELSE BEGIN
		UPDATE UsersGames
		SET Cash -= @sum1
		WHERE Id = 110

		INSERT INTO UserGameItems (UserGameId, ItemId)
		SELECT 110, Id 
		FROM Items 
		WHERE MinLevel BETWEEN 11 AND 12
		COMMIT
	END

BEGIN TRANSACTION
DECLARE @sum2 MONEY = (SELECT SUM(i.Price)
						FROM Items i
						WHERE MinLevel BETWEEN 19 AND 21)

IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum2
ROLLBACK
ELSE BEGIN
		UPDATE UsersGames
		SET Cash -= @sum2
		WHERE Id = 110

		INSERT INTO UserGameItems (UserGameId, ItemId)
			SELECT 110, Id 
			FROM Items 
			WHERE MinLevel BETWEEN 19 AND 21
		COMMIT
	END

SELECT i.[Name] AS 'Item Name' 
FROM UserGameItems ugi
INNER JOIN Items AS i
ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = 110



-------
SET XACT_ABORT ON 
BEGIN TRANSACTION [Tran1]

BEGIN TRY
	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 11 AND 12

COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
END CATCH 
GO

BEGIN TRANSACTION [Tran2]

BEGIN TRY
	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 19 AND 21

COMMIT TRANSACTION [Tran2]
END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran2]
END CATCH
GO
--08. Employees with Three Projects
USE SoftUni
GO

CREATE PROC udp_AssignProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3
	DECLARE @employeeProjectsCount INT
	SET @employeeProjectsCount = (SELECT COUNT(*) 
		FROM EmployeesProjects AS ep
		WHERE ep.EmployeeId = @EmployeeID
	)
	BEGIN TRAN
		INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)
		
		IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
		BEGIN
			RAISERROR('The employee has too many projects!', 16, 1)
			ROLLBACK
		END
		ELSE
			COMMIT
END
GO
--09. Delete Employees
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId INT,
	Salary DECIMAL (15, 2)
)
GO

CREATE TRIGGER tr_DeleteEmployee ON Employees
AFTER DELETE 
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary 
	FROM deleted
END
GO

DELETE FROM Employees
WHERE EmployeeID = 293