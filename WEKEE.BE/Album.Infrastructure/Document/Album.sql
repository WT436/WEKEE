CREATE DATABASE [Album]
GO
USE [Album]
GO
CREATE TABLE [IMAGE]
(
	   [id] INT IDENTITY(1,1) PRIMARY KEY,
	   [name] VARCHAR(300) NULL,
	   [type] VARCHAR(300) NOT NULL,
	   [folser] VARCHAR(50) NOT NULL,
	   [size] VARCHAR(50) NOT NULL,
	   [capacity] INT NOT NULL,
	   [alt] NVARCHAR(300) NULL,
	   [description] NVARCHAR(Max),
	   [dateCreate] DATETIME,
	   [IsActive] BIT DEFAULT 1,
)