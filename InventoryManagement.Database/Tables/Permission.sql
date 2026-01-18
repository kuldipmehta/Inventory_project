CREATE TABLE [dbo].[Permission](
	[PermissionId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[PermissionName] VARCHAR(120) NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT 1,
	[CreatedBy] INT NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[UpdatedBy] INT NULL,
	[UpdatedDate] DATETIME NULL,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
)