
-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Insert a new Customer Category.
-- =============================================
CREATE PROCEDURE [dbo].[AddCustomerCategory]
  @CustomerCategoryName VARCHAR(100)
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.CustomerCategories A Where A.CustomerCategoryName = @CustomerCategoryName)
  BEGIN
	SET @ErrorMessage = 'Customer category name ' + @CustomerCategoryName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.CustomerCategories
  (
	CustomerCategoryName
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (  
	@CustomerCategoryName
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