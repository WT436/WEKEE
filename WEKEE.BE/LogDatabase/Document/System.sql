CREATE DATABASE [DbSystem]
GO
Use [DbSystem]
GO
CREATE TABLE [dbo].[ExceptionLog](  
[id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
[serverError] NVARCHAR(100) NULL,
[account_create] INT,
[ip_account] varchar(20),
[level] VARCHAR(10) NULL,
[errorMessage] NVARCHAR(3000) NULL,
[errorTrace] NVARCHAR(MAX) NULL,
[dateRaised] DATETIME NULL ,
[dateUpdate] DATETIME NULL,
[updateCount] INT DEFAULT(0) NOT NULL
)