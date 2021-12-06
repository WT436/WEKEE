CREATE DATABASE [Evaluates]
GO
USE [Evaluates]
GO
-- số sao;
CREATE TABLE [EvaluatesProduct](
	[id] INT IDENTITY(1,1)  PRIMARY KEY,
	[content] NVARCHAR(max) NOT NULL, -- đánh giá
	[starNumber] INT NULL DEFAULT ((3)) CHECK(([starNumber]>=(1) AND [starNumber]<=(5))), -- số sao
	[pinFeeling] NVARCHAR(MAX) NULL,-- ghim cảm giác nổi bật
	[tagAccount] NVARCHAR(30) NULL,-- list id người dùng
	[levelEvaluates] INT NOT NULL DEFAULT(0), -- lưu like cho rep hay eva
	[idEvaluatesProduct] INT NULL FOREIGN KEY REFERENCES [EvaluatesProduct] (id),
	[product] INT NOT NULL,
	[account] INT NOT NULL,
	[dateCreate] DATETIME NULL DEFAULT (GETDATE()),
	[dateUpdate] DATETIME NULL DEFAULT (GETDATE())
)
GO
/******    Like Đánh giá  X  *****/
CREATE TABLE [LikeEvaluatesProduct](
	[id] INT IDENTITY(1,1) NOT NULL  PRIMARY KEY,
	[islike] BIT NULL,
	[isdislike] BIT NULL,
	[levelEvaluates] INT NOT NULL, -- lưu like cho rep hay eva 
	[idEvaluates] INT NOT NULL,
	[account] INT NOT NULL,
	[dateCreate] DATETIME NULL DEFAULT (GETDATE()),
	[dateUpdate] DATETIME NULL DEFAULT (GETDATE())
)
GO
CREATE TABLE [ImageEvaluatesProduct]
(
	[id] INT IDENTITY(1,1) NOT NULL  PRIMARY KEY,
	[src] VARCHAR(max) NOT NULL,-- là đường dẫn ảnh
	[alt] NVARCHAR(300) NOT NULL,
	[title] NVARCHAR(300) NOT NULL,
	[size] VARCHAR(20) NOT NULL,
	[folder] VARCHAR(50) NOT NULL,
	[imageRoot] INT FOREIGN KEY REFERENCES [ImageEvaluatesProduct] (id),
	[typesImage] BIT NOT NULL , -- lưu like cho rep hay eva
	[idEvaluatesProduct] INT NOT NULL,
	[isEnabled] BIT NOT NULL DEFAULT (0),
	[dateCreate] DATETIME NULL DEFAULT (GETDATE()),
	[dateUpdate] DATETIME NULL DEFAULT (GETDATE()),
)