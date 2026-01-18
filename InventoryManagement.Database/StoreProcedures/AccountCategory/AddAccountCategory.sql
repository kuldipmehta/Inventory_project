-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Insert a new Account Category.
-- =============================================
CREATE PROCEDURE [dbo].[AddAccountCategory]
  @CategoryName	VARCHAR(60)  
  ,@ShortCode VARCHAR(10)  
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.AccountCategories A Where A.CategoryName = @CategoryName)
  BEGIN
	SET @ErrorMessage = 'Category name ' + @CategoryName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.AccountCategories
  (
	CategoryName
	,ShortCode
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CategoryName
	,@ShortCode
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