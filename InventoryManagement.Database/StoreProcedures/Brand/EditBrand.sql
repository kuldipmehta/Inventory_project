-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Edit a Brand.
-- =============================================
CREATE PROCEDURE [dbo].[EditBrand]
(
  @BrandId INT
  ,@BrandName VARCHAR(150)
  ,@ShortName VARCHAR(20)
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

   IF EXISTS(SELECT 1 FROM dbo.Brands A Where A.BrandName = @BrandName AND A.BrandId <> @BrandId)
  BEGIN
	SET @ErrorMessage = 'Brand name ' + @BrandName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Brands A Where A.ShortName = @ShortName AND A.BrandId <> @BrandId)
  BEGIN
	SET @ErrorMessage = 'Short name ' + @ShortName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Brands B Where B.SrNo = @SrNo AND B.BrandId <> @BrandId)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END
	-- Edit details.
  UPDATE 
    dbo.Brands
  SET 
    BrandName = @BrandName
	,ShortName = @ShortName
	,SrNo = @SrNo
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    BrandId = @BrandId 
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