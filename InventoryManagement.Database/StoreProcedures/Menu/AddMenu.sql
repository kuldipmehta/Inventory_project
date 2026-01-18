-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Insert a new Menu.
-- =============================================
CREATE PROCEDURE [dbo].[AddMenu]
  @MenuName VARCHAR(100)
  ,@DisplayName VARCHAR(120)
  ,@Type VARCHAR(50)
  ,@Url VARCHAR(120)
  ,@Icon VARCHAR(50)
  ,@ParentId INT 
  ,@Permissions VARCHAR(500)
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Menu A Where A.MenuName = @MenuName)
  BEGIN
	SET @ErrorMessage = 'Menu name ' + @MenuName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Menu
  (
	MenuName
	,DisplayName
	,[Type]
	,[Url]
	,Icon
	,ParentId
	,[Permissions]
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@MenuName
	,@DisplayName
	,@Type
	,@Url
	,@Icon
	,@ParentId
	,@Permissions
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