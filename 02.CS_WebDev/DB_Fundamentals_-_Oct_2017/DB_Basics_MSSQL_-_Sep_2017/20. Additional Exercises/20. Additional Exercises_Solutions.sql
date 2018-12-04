--01. Number of Users for Email Provider
USE Diablo 
GO

SELECT
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) as [Email Provider],
	COUNT(Username) [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))
ORDER BY COUNT(Username) DESC, [Email Provider]

--02. All Users in Games
SELECT g.Name AS Game, gt.Name AS [Game Type], u.Username, ug.Level, ug.Cash, c.Name AS Character FROM Games AS g
JOIN GameTypes gt ON gt.Id = g.GameTypeId
JOIN UsersGames ug ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
JOIN Characters c ON c.Id = ug.CharacterId
ORDER BY Level DESC, Username, Game

--03. Users in Games with Their Items
SELECT u.Username,
	g.Name AS Game,
	COUNT(i.Id) AS [Items Count],
	SUM(i.Price) AS [Items Price] 
FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
JOIN Characters c ON ug.CharacterId = c.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username

--04. * User in Games with Their Statistics
SELECT 
	u.Username, 
	g.Name as Game, 
	MAX(c.Name) Character,
	SUM(its.Strength) + MAX(gts.Strength) + MAX(cs.Strength) AS Strength,
	SUM(its.Defence) + MAX(gts.Defence) + MAX(cs.Defence) AS Defence,
	SUM(its.Speed) + MAX(gts.Speed) + MAX(cs.Speed) AS Speed,
	SUM(its.Mind) + MAX(gts.Mind) + MAX(cs.Mind) AS Mind,
	SUM(its.Luck) + MAX(gts.Luck) + MAX(cs.Luck) AS Luck
FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
JOIN GameTypes gt ON gt.Id = g.GameTypeId
JOIN [Statistics] gts ON gts.Id = gt.BonusStatsId
JOIN Characters c ON ug.CharacterId = c.Id
JOIN [Statistics] cs ON cs.Id = c.StatisticId
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
JOIN [Statistics] its ON its.Id = i.StatisticId
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

--05. All Items with Greater than Average Statistics
SELECT 
	i.Name, 
	i.Price, 
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
FROM Items i
JOIN [Statistics] s on s.Id = i.StatisticId
WHERE s.Mind > (
	SELECT AVG(s.Mind) FROM Items i 
	JOIN [Statistics] s ON s.Id = i.StatisticId
) AND s.Luck > (
	SELECT AVG(s.Luck) FROM Items i 
	JOIN [Statistics] s ON s.Id = i.StatisticId
) AND s.Speed > (
	SELECT AVG(s.Speed) FROM Items i 
	JOIN [Statistics] s ON s.Id = i.StatisticId
) 
ORDER BY i.Name

--06. Display All Items with information about Forbidden Game Type
SELECT i.Name AS Item, 
	Price, MinLevel, 
	gt.Name AS [Forbidden Game Type] 
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems gtf ON gtf.ItemId = i.Id
LEFT JOIN GameTypes gt ON gt.Id = gtf.GameTypeId
ORDER BY [Forbidden Game Type] DESC, Item

--07. Buy Items for User in Game
INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES 
	(
		(SELECT Id FROM Items WHERE Name = 'Blackguard'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Blackguard')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES 
	(
		(SELECT Id FROM Items WHERE Name = 'Bottomless Potion of Amplification'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Bottomless Potion of Amplification')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Eye of Etlich (Diablo III)')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u on u.Id = ug.UserId
	JOIN Games g on g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Gem of Efficacious Toxin')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Golden Gorget of Leoric')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

	
INSERT INTO UserGameItems(ItemId, UserGameId)
VALUES (
		(SELECT Id FROM Items WHERE Name = 'Hellfire Amulet'), 
		(SELECT ug.Id FROM UsersGames ug 
			JOIN Users u ON u.Id = ug.UserId
			JOIN Games g ON g.Id = ug.GameId
			WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')
	)

UPDATE UsersGames
SET Cash = Cash - (SELECT Price FROM Items WHERE Name = 'Hellfire Amulet')
WHERE Id = (SELECT ug.Id FROM UsersGames ug 
	JOIN Users u ON u.Id = ug.UserId
	JOIN Games g ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh')

SELECT u.Username, g.Name, ug.Cash, i.Name [Item Name] from UsersGames ug
JOIN Games g ON ug.GameId = g.Id
JOIN Users u ON ug.UserId = u.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name

--PART IV – Queries for Geography Database
--08. Peaks and Mountains
USE Geography
GO

SELECT 
	PeakName, 
	MountainRange as Mountain, 
	Elevation
FROM 
	Peaks p 
	JOIN Mountains m ON p.MountainId = m.Id
ORDER BY Elevation DESC, PeakName

--09. Peaks with Their Mountain, Country and Continent
SELECT 
	PeakName, MountainRange as Mountain, c.CountryName, cn.ContinentName
FROM 
	Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	JOIN MountainsCountries mc ON m.Id = mc.MountainId
	JOIN Countries c ON c.CountryCode = mc.CountryCode
	JOIN Continents cn ON cn.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName

--10. Rivers by Country
SELECT
	c.CountryName, ct.ContinentName,
	COUNT(r.RiverName) AS RiversCount,
	ISNULL(SUM(r.Length), 0) AS TotalLength
FROM
	Countries c
	LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryName, ct.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName

--11. Count of Countries by Currency
SELECT
	cur.CurrencyCode,
	MIN(cur.Description) AS Currency,
	COUNT(c.CountryName) AS NumberOfCountries
FROM
	Currencies cur
	LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
ORDER BY NumberOfCountries DESC, Currency ASC

--12. Population and Area by Continent
SELECT
	ct.ContinentName,
	SUM(CONVERT(numeric, c.AreaInSqKm)) AS CountriesArea,
	SUM(CONVERT(numeric, c.Population)) AS CountriesPopulation
FROM
	Countries c
	LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
GROUP BY ct.ContinentName
ORDER BY CountriesPopulation DESC

--Problem 13. Monasteries by Country
CREATE TABLE Monasteries(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50),
	CountryCode CHAR(2)
	CONSTRAINT FK_Monasteries_Countries
		FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
)


INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sumela Monastery', 'TR') -- u must be u-umlaut

--START Exclude from Judge
ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL
DEFAULT 0
--END Exclude from Judge

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
	SELECT c.CountryCode
	FROM Countries c
		JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
		JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryCode
	HAVING COUNT(r.Id) > 3
)

SELECT 
	m.Name AS Monastery, c.CountryName AS Country
FROM 
	Countries c
	JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

--14. Monasteries by Continents and Countries
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Maynmar'))

SELECT ct.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount
FROM Continents ct
	LEFT JOIN Countries c ON ct.ContinentCode = c.ContinentCode
	LEFT JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY ct.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName