-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Insert a new Brand.
-- =============================================
CREATE PROCEDURE [dbo].[AddBrand]
  @BrandName VARCHAR(150)
  ,@ShortName VARCHAR(20)
  ,@SrNo INT
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Brands A Where A.BrandName = @BrandName)
  BEGIN
	SET @ErrorMessage = 'Brand name ' + @BrandName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Brands A Where A.ShortName = @ShortName)
  BEGIN
	SET @ErrorMessage = 'Short name ' + @ShortName + ' already exists.'
	RETURN 1001;
  END
   
  IF EXISTS(SELECT 1 FROM dbo.Brands B Where B.SrNo = @SrNo)
  BEGIN
	SET @ErrorMessage = 'Sr no ' + @SrNo + ' already exists.'
	RETURN 1001;
  END
  -- Insert the New value.
  INSERT INTO dbo.Brands
  (
	BrandName
	,ShortName
	,SrNo
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@BrandName
	,@ShortName
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