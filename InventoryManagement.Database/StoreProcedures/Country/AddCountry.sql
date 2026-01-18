-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Insert a new Country.
-- =============================================
CREATE PROCEDURE [dbo].[AddCountry]
  @CountryName VARCHAR(100)
  ,@CountryCode VARCHAR(20)
  ,@MobileFixCode VARCHAR(15)
  ,@CurrencyRate FLOAT  
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Country A Where A.CountryName = @CountryName)
  BEGIN
	SET @ErrorMessage = 'Country name ' + @CountryName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Country
  (
	CountryName
	,CountryCode
	,MobileFixCode
	,CurrencyRate 
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CountryName
	,@CountryCode
	,@MobileFixCode
	,@CurrencyRate 
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