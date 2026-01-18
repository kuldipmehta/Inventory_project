CREATE TABLE [dbo].[RolePermissions](
	[RolePermissionId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[RoleId] INT NOT NULL,
	[MenuId] INT NOT NULL,
	[PermissionId] INT NOT NULL,
	[HasPermission] BIT NOT NULL,
	--[IsActive] BIT NOT NULL DEFAULT 1,
	--[CreatedBy] INT NOT NULL,
	--[CreatedDate] DATETIME NOT NULL ,
	--[UpdatedBy] INT NULL,
	--[UpdatedDate] DATETIME NULL,
	[ChangeTimeStamp] ROWVERSION NOT NULL,
)