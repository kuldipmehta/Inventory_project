-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Insert a new Color.
-- =============================================
CREATE PROCEDURE [dbo].[AddColor]
  @ColorName VARCHAR(100)
  ,@SrNo INT
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Colors A Where A.ColorName = @ColorName)
  BEGIN
	SET @ErrorMessage = 'Color name ' + @ColorName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Colors C Where C.SrNo = @SrNo)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Colors
  (
	ColorName
	,SrNo
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@ColorName
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