-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 21/03/2019
-- Description : Returns the Role Permisstion details
-- ========================================================
CREATE PROCEDURE [dbo].[GetRolePermisstionDetails]
  @RoleId AS INT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  SELECT
    RP.RolePermissionId
	,RP.RoleId
	,RP.MenuId
	,RP.PermissionId
	,RP.HasPermission
	--,RP.IsActive
	--,RP.CreatedBy
	--,RP.CreatedDate
	--,RP.UpdatedBy
	--,RP.UpdatedDate
	,RP.ChangeTimeStamp
  FROM
    dbo.RolePermissions RP
  WHERE
    RP.RoleId = @RoleId

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO