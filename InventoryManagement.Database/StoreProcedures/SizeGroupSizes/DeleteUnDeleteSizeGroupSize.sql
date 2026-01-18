-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Deletes/UnDelete a Size Group Size.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteSizeGroupSize]
(
  @SizeGroupSizeId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set SizeGroupSize Deleted state.
  UPDATE
    dbo.SizeGroupSizes
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    SizeGroupSizeId = @SizeGroupSizeId
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