-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Insert a new Size Group Size.
-- =============================================
CREATE PROCEDURE [dbo].[AddSizeGroupSize]
  @SizeGroupId INT			 
  ,@SizeShortName VARCHAR(25)  
  ,@SrNo INT			 
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.SizeGroupSizes SGS Where SGS.SizeShortName = @SizeShortName)
  BEGIN
	SET @ErrorMessage = 'Size short name ' + @SizeShortName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.SizeGroupSizes SGS Where SGS.SrNo = @SrNo)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.SizeGroupSizes
  (
	SizeGroupId
	,SizeShortName
	,SrNo
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    @SizeGroupId
	,@SizeShortName
	,@SrNo
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END