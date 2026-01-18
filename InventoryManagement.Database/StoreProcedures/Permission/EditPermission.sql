-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Edit a Permission.
-- =============================================
CREATE PROCEDURE [dbo].[EditPermission]
(
  @PermissionId INT
  ,@PermissionName VARCHAR(120)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;
	
	 IF EXISTS(SELECT 1 FROM dbo.Permission P Where P.PermissionName = @PermissionName AND P.PermissionId <> @PermissionId)
	 BEGIN
	 	SET @ErrorMessage = 'Permission name ' + @PermissionName + ' already exists.'
	 	RETURN 1001;
	 END

	-- Edit details.
	UPDATE 
	  [dbo].Permission
	SET 
	  PermissionName = @PermissionName
	  ,UpdatedBy = @UpdatedBy
	  ,UpdatedDate  = GETDATE()
	WHERE 
	  PermissionId = @PermissionId 
	  AND ChangeTimeStamp = @ChangeTimeStamp
	
  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END