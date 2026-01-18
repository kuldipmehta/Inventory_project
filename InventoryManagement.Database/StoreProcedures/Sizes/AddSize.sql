-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Insert a new Size.
-- =============================================
CREATE PROCEDURE [dbo].[AddSize]
  @SizeName VARCHAR(30)  
  ,@ShortName VARCHAR(25)  
  ,@SrNo INT	
  ,@SizeCountryType dbo.SizeCountryType READONLY
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Sizes S Where S.SizeName = @SizeName)
  BEGIN
	SET @ErrorMessage = 'Size name ' + @SizeName + ' already exists.'
	RETURN 1001;
  END

  
  IF EXISTS(SELECT 1 FROM dbo.Sizes S Where S.ShortName = @ShortName)
  BEGIN
	SET @ErrorMessage = 'Short name ' + @ShortName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Sizes S Where S.SrNo = @SrNo)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Sizes
  (
	SizeName
	,ShortName
	,SrNo
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@SizeName
	,@ShortName
	,@SrNo
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  EXEC dbo.MergeSizeCountries @ShortName, @CreatedBy, @SizeCountryType

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END