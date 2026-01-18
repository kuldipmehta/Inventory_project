CREATE TYPE [dbo].[RolePermissionType] AS TABLE(
    [MenuId] INT NOT NULL,
	[PermissionId] INT NOT NULL,
	[HasPermission] BIT NOT NULL
)