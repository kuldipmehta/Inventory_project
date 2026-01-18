-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Synchronizes the Role - Permissions.
-- ========================================================
CREATE PROCEDURE [dbo].[MergeRolePermissions]
  @RoleId AS TINYINT,
  @RolePermissionType dbo.RolePermissionType READONLY
AS
BEGIN 
BEGIN TRY
  SET NOCOUNT ON;

  --Merge the Permissions Details.	
	MERGE
		dbo.RolePermissions
	AS T
	USING (SELECT 
			@RoleId AS RoleId,
			MenuId,
			PermissionId,
			HasPermission
         FROM 
          @RolePermissionType) AS S
		ON T.RoleId = S.RoleId 
	       AND T.PermissionId = S.PermissionId
		   AND T.MenuId = S.MenuId
	WHEN NOT MATCHED BY TARGET THEN --Insert Rows.
	INSERT 
	(
		[RoleId]
		,[MenuId]
		,[PermissionId]
		,[HasPermission]
	) 
	VALUES
	(
		S.RoleId
		,S.MenuId
		,S.PermissionId
		,S.HasPermission
	)
	WHEN MATCHED THEN --Update Rows.
	UPDATE
	SET
		HasPermission = S.HasPermission
	WHEN NOT MATCHED BY SOURCE AND T.RoleId = @RoleId THEN --Delete Rows.
	DELETE;

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END