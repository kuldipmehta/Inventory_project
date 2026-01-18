-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Deletes/UnDelete a HSN Code.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteHSNCode]
(
  @HSNCodeId INT			 
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set HSNCode Deleted state.
  UPDATE
    dbo.HSNCodes
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    HSNCodeId = @HSNCodeId
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