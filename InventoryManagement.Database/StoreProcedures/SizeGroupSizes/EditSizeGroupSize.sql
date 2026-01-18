-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Edit a Size Group Size.
-- =============================================
CREATE PROCEDURE [dbo].[EditSizeGroupSize]
(
  @SizeGroupSizeId INT
  ,@SizeGroupId INT			
  ,@SizeShortName VARCHAR(25) 
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

  IF EXISTS(SELECT 1 FROM dbo.SizeGroupSizes SGS Where SGS.SizeShortName = @SizeShortName AND SGS.SizeGroupSizeId <> @SizeGroupSizeId)
  BEGIN
	SET @ErrorMessage = 'Size short name' + @SizeShortName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.SizeGroupSizes SGS Where SGS.SrNo = @SrNo AND SGS.SizeGroupSizeId <> @SizeGroupSizeId)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.SizeGroupSizes
  SET 
    SizeGroupId = @SizeGroupId
	,SizeShortName = @SizeShortName
	,SrNo = @SrNo
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    SizeGroupSizeId = @SizeGroupSizeId 
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