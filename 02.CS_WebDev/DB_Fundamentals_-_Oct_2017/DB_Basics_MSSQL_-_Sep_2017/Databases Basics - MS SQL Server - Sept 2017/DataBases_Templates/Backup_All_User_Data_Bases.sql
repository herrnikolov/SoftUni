--https://gallery.technet.microsoft.com/scriptcenter/T-SQL-to-backup-all-d683cfee

DECLARE @name VARCHAR(50) -- database name   
DECLARE @path VARCHAR(256) -- path for backup files   
DECLARE @fileName VARCHAR(256) -- filename for backup   
DECLARE @fileDate VARCHAR(20) -- used for file name  
 
--Provide the path where all the databases needs to be backed up 
SET @path = 'C:\GitHub\SoftUni_-_DB_Fundamentals\Databases Basics - MS SQL Server - Sept 2017\DBBackups\'   
 
--used to suffix the current date at the end of backup filename 
SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112)  
 
DECLARE db_cursor CURSOR FOR   
 
--Use this for all database except the system databases and any exclusion you can make 
SELECT name  
FROM master.dbo.sysdatabases  
WHERE name NOT IN ('master','model','msdb','tempdb','ReportServer','ReportServerTempDB')   
 
--Uncomment and use this for only specific databases. 
--Those database names you can provide under IN clause 
--SELECT name  
--FROM master.dbo.sysdatabases  
--WHERE name IN ('MyDB1','MyDB2')  
 
OPEN db_cursor    
FETCH NEXT FROM db_cursor INTO @name    
 
WHILE @@FETCH_STATUS = 0    
BEGIN    
       SET @fileName = @path + @name + '_' + @fileDate + '.BAK'   
       BACKUP DATABASE @name TO DISK = @fileName WITH STATS = 1   
 
       FETCH NEXT FROM db_cursor INTO @name    
END    
 
CLOSE db_cursor    
DEALLOCATE db_cursor 
