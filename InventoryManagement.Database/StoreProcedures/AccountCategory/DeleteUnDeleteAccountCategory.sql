-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Deletes/UnDelete a Account Category.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteAccountCategory]
(
  @AccountCategoryId AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set AccountCategory Deleted state.
  UPDATE
    dbo.AccountCategories
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    AccountCategoryId = @AccountCategoryId
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