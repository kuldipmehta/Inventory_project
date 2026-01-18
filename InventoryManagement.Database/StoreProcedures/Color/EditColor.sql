-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Edit a Color.
-- =============================================
CREATE PROCEDURE [dbo].[EditColor]
(
  @ColorId INT
  ,@ColorName VARCHAR(100)
  ,@SrNo INT
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Colors C Where C.ColorName = @ColorName AND C.ColorId <> @ColorId)
  BEGIN
	SET @ErrorMessage = 'Color name ' + @ColorName + ' already exists.'
	RETURN 1001;
  END
  
  IF EXISTS(SELECT 1 FROM dbo.Colors C Where C.SrNo = @SrNo AND C.ColorId <> @ColorId)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END
	-- Edit details.
  UPDATE 
    dbo.Colors
  SET 
    ColorName = @ColorName
	,SrNo = @SrNo
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    ColorId = @ColorId 
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