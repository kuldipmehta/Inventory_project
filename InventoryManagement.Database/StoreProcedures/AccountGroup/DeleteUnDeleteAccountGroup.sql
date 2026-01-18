-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Deletes/UnDelete a AccountGroup.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteAccountGroup]
(
  @GroupId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set AccountGroup Deleted state.
  UPDATE
    dbo.AccountGroups
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    GroupId = @GroupId
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