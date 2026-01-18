-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Deletes/UnDelete a Style.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteStyle]
(
  @StyleId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set Style Deleted state.
  UPDATE
    dbo.Styles
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    StyleId = @StyleId
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