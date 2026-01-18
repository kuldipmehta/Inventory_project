-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Deletes/UnDelete a Permission.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeletePermission]
(
  @PermissionId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set Permission Deleted state.
  UPDATE
    dbo.Permission
  SET
    IsActive = @IsActive
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = GETDATE()
  WHERE
    PermissionId = @PermissionId
    AND IsActive <> @IsActive
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