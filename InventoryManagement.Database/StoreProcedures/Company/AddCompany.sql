-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Insert a new Company.
-- =============================================
CREATE PROCEDURE [dbo].[AddCompany]
  @CompanyName VARCHAR(100) 
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
  ,@CompanyTypeId INT
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Companies C Where C.CompanyName = @CompanyName)
  BEGIN
	SET @ErrorMessage = 'Company name ' + @CompanyName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Companies
  (
	CompanyName
	,SubCompanyName
	,ShortName
	,BusinessTypeId
	,Address	   
	,CityId			   
	,StateId
	,Pincode
	,PhoneNo
	,MobileNo
	,EmailId			   
	,WebSite			   
	,GSTNo			   
	,PANNO			   
	,JurisDiction
	,CurrentBranchId
	,WithOutBarcodeOption
	,CompositionScheme  
	,TaxPayerTypeId
	,CompanyTypeId	       
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CompanyName
	,@SubCompanyName
	,@ShortName
	,@BusinessTypeId
	,@Address	   
	,@CityId			   
	,@StateId
	,@Pincode
	,@PhoneNo
	,@MobileNo
	,@EmailId			   
	,@WebSite			   
	,@GSTNo			   
	,@PANNO			   
	,@JurisDiction
	,@CurrentBranchId
	,@WithOutBarcodeOption
	,@CompositionScheme  
	,@TaxPayerTypeId
	,@CompanyTypeId	   
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