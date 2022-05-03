CREATE DATABASE [SystemDB]
GO
Use [SystemDB]
GO
CREATE TABLE [dbo].[ExceptionLog](  
[id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
[serverError] NVARCHAR(100) NULL,
[account_create] INT,
[ip_account] varchar(20),
[level] VARCHAR(10) NULL,
[errorMessage] NVARCHAR(3000) NULL,
[errorTrace] NVARCHAR(MAX) NULL,
[dateRaised] DATETIME NOT NULL DEFAULT GETDATE(),
[UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
[updateCount] INT DEFAULT(0) NOT NULL,
[isFix] BIT DEFAULT 0
)
GO
GO
CREATE TABLE [dbo].[Download](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DownloadGuid] [uniqueidentifier] NOT NULL,
	[UseDownloadUrl] [bit] NOT NULL,
	[DownloadUrl] [nvarchar](max) NULL,
	[DownloadBinary] [varbinary](max) NULL,
	[ContentType] [nvarchar](max) NULL,
	[Filename] [nvarchar](max) NULL,
	[Extension] [nvarchar](max) NULL,
	[IsNew] [bit] NOT NULL
)
GO
CREATE TABLE [dbo].[CategoryTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[ViewPath] [nvarchar](400) NOT NULL,
	[DisplayOrder] [int] NOT NULL
)
GO

CREATE TABLE [dbo].[EasyPostBatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BatchId] [nvarchar](max) NULL,
	[BatchGuid] [uniqueidentifier] NOT NULL,
	[StatusId] [int] NOT NULL,
	[LabelFormat] [nvarchar](max) NULL,
	[ManifestUrl] [nvarchar](max) NULL,
	[ShipmentIds] [nvarchar](max) NULL,
	[PickupId] [nvarchar](max) NULL,
	[UpdatedOnUtc] [datetime2](7) NOT NULL,
	[CreatedOnUtc] [datetime2](7) NOT NULL
)