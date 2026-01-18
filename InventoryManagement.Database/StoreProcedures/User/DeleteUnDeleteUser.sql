-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Deletes/UnDelete a User.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteUser]
(
  @UserId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set User Deleted state.
  UPDATE
    dbo.ApplicationUser
  SET
    IsActive = @IsActive
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = GETDATE()	
  WHERE
    Id = @UserId
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