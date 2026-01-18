-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Edit a Company.
-- =============================================
CREATE PROCEDURE [dbo].[EditCompany]
(
  @CompanyId INT
  ,@CompanyName VARCHAR(100) 
  ,@SubCompanyName VARCHAR(100) 
  ,@ShortName VARCHAR(10)	
  ,@BusinessTypeId INT			
  ,@Address VARCHAR(250) 
  ,@CityId INT			
  ,@StateId INT			
  ,@Pincode VARCHAR(10)  
  ,@PhoneNo VARCHAR(30)  
  ,@MobileNo VARCHAR(15)  
  ,@EmailId VARCHAR(125) 
  ,@WebSite VARCHAR(60)  
  ,@GSTNo VARCHAR(50)  
  ,@PANNO VARCHAR(30)  
  ,@JurisDiction  VARCHAR(150) 
  ,@CurrentBranchId INT			
  ,@WithOutBarcodeOption BIT		    
  ,@CompositionScheme BIT			
  ,@TaxPayerTypeId CHAR(1)
  ,@CompanyTypeId  INT
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Companies C Where C.CompanyName = @CompanyName AND C.CompanyId <> @CompanyId)
  BEGIN
	SET @ErrorMessage = 'Company name ' + @CompanyName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Companies
  SET 
    CompanyName = @CompanyName	   
	,SubCompanyName = @SubCompanyName
	,ShortName = @ShortName	   
	,BusinessTypeId = @BusinessTypeId
	,Address = @Address
	,CityId = @CityId			   
	,StateId = @StateId
	,Pincode = @Pincode
	,PhoneNo = @PhoneNo
	,MobileNo = @MobileNo
	,EmailId = @EmailId
	,WebSite = @WebSite
	,GSTNo = @GSTNo		   
	,PANNO = @PANNO		   
	,JurisDiction = @JurisDiction	   
	,CurrentBranchId = @CurrentBranchId   
	,WithOutBarcodeOption = @WithOutBarcodeOption
	,CompositionScheme = @CompositionScheme
	,TaxPayerTypeId = @TaxPayerTypeId
	,CompanyTypeId = @CompanyTypeId 
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    CompanyId = @CompanyId 
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