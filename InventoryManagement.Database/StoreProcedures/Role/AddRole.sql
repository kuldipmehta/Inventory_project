-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Insert a new Role.
-- =============================================
CREATE PROCEDURE [dbo].[AddRole]
  @Name VARCHAR(256)
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.ApplicationRole A Where A.Name = @Name)
  BEGIN
	SET @ErrorMessage = 'Role name ' + @Name + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.ApplicationRole
  (
	Name
	,NormalizedName	
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@Name
	,UPPER(@Name)
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