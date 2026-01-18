-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Deletes/UnDelete a Role.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteRole]
(
  @Id	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set Role Deleted state.
  UPDATE
    dbo.ApplicationRole
  SET
    IsActive = @IsActive
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = GETDATE()
  WHERE
    Id = @Id
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