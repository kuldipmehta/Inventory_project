CREATE TABLE [dbo].[Menu](
	[MenuId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[MenuName] VARCHAR(120) NOT NULL,
	[DisplayName] VARCHAR(120) NOT NULL,
	[Type] VARCHAR(50) NOT NULL,
	[Url] VARCHAR(120) NOT NULL,
	[Icon] VARCHAR(50) NOT NULL,
	[ParentId] INT NULL,
	[Permissions] VARCHAR(500) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[UpdatedBy] INT NULL,
	[UpdatedDate] DATETIME NULL,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
	[SrNo] [int] NULL
)