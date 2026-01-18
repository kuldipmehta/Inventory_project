-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Edit a Country.
-- =============================================
CREATE PROCEDURE [dbo].[EditCountry]
(
  @CountryId INT
  ,@CountryName VARCHAR(100)
  ,@CountryCode VARCHAR(20)
  ,@MobileFixCode VARCHAR(15)
  ,@CurrencyRate FLOAT  
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM dbo.Country A Where A.CountryName = @CountryName AND A.CountryId <> @CountryId)
	BEGIN
		SET @ErrorMessage = 'Country name ' + @CountryName + ' already exists.'
		RETURN 1001;
	END

	-- Edit details.
  UPDATE 
    [dbo].Country
  SET 
    CountryName = @CountryName
	,CountryCode = @CountryCode 
	,MobileFixCode = @MobileFixCode
	,CurrencyRate = @CurrencyRate
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = GETDATE()
  WHERE 
    CountryId = @CountryId 
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