-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Edit a Size.
-- =============================================
CREATE PROCEDURE [dbo].[EditSize]
(
  @SizeId INT
  ,@SizeName VARCHAR(30)  
  ,@ShortName VARCHAR(25)  
  ,@SrNo INT		
  ,@SizeCountryType dbo.SizeCountryType READONLY
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Sizes S Where S.SizeName = @SizeName AND S.SizeId <> @SizeId)
  BEGIN
	SET @ErrorMessage = 'Size name ' + @SizeName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Sizes S Where S.ShortName = @ShortName AND S.SizeId <> @SizeId)
  BEGIN
	SET @ErrorMessage = 'Short name ' + @ShortName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Sizes S Where S.SrNo = @SrNo AND S.SizeId <> @SizeId)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Sizes
  SET 
    SizeName = @SizeName
	,ShortName = @ShortName
	,SrNo = @SrNo
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    SizeId = @SizeId 
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

 EXEC dbo.MergeSizeCountries @ShortName, @UpdatedBy, @SizeCountryType

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END