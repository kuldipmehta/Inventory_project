-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Edit a Account Category.
-- =============================================
CREATE PROCEDURE [dbo].[EditAccountCategory]
(
  @AccountCategoryId INT
  ,@CategoryName	VARCHAR(60)  
  ,@ShortCode VARCHAR(10)  
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.AccountCategories A Where A.CategoryName = @CategoryName AND A.AccountCategoryId <> @AccountCategoryId)
  BEGIN
	SET @ErrorMessage = 'Category name ' + @CategoryName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.AccountCategories
  SET 
	CategoryName = @CategoryName
	,ShortCode = @ShortCode
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    AccountCategoryId = @AccountCategoryId 
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