-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Edit a Customer Category.
-- =============================================
CREATE PROCEDURE [dbo].[EditCustomerCategory]
(
  @CustomerCategoryId INT
  ,@CustomerCategoryName VARCHAR(100)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.CustomerCategories A Where A.CustomerCategoryName = @CustomerCategoryName AND A.CustomerCategoryId <> @CustomerCategoryId)
  BEGIN
	SET @ErrorMessage = 'Customer Category name ' + @CustomerCategoryName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.CustomerCategories
  SET 
    CustomerCategoryName = @CustomerCategoryName
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    CustomerCategoryId = @CustomerCategoryId 
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