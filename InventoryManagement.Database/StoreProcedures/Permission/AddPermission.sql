-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Insert a new Permission.
-- =============================================
CREATE PROCEDURE [dbo].[AddPermission]
  @PermissionName VARCHAR(120)
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Permission A Where A.PermissionName = @PermissionName)
  BEGIN
	SET @ErrorMessage = 'Permission name ' + @PermissionName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Permission
  (
	PermissionName
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@PermissionName
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END