use master

alter procedure CreateDB
@dbName nvarchar(15),
@dbFileName nvarchar(25),
@dbFilePath nvarchar(25),
@trFileName nvarchar(25),
@trFilePath nvarchar(25)
as
declare 
@sqlString nvarchar(max) 
set @sqlString = 'create database ' + @dbName + 
'ON primary
( NAME = ' + @dbFileName
+ ' , FILENAME = ' + @dbFilePath
+ ' , SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = ' + @trFileName 
+ ' ,  FILENAME = ' + @trFilePath
+ ' , SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB ) ;'
exec (@sqlString)

go
exec CreateDB 'myNewDb', 
'newDbData',
'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\newDb.mdf',
'newDbLog',
'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\newDb.ldf'