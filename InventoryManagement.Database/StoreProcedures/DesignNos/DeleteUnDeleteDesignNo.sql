-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Deletes/UnDelete a DesignNo.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteDesignNo]
(
  @DesignNoId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set DesignNo Deleted state.
  UPDATE
    dbo.DesignNos
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    DesignNoId = @DesignNoId
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