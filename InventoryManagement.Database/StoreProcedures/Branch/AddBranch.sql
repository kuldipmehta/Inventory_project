-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Insert a new Branch.
-- =============================================
CREATE PROCEDURE [dbo].[AddBranch] 
  @CompanyId INT			
  ,@BranchName VARCHAR(150)
  ,@BranchType VARCHAR(2)  
  ,@BranchVoucherNoPrefix VARCHAR(5)  
  ,@Address VARCHAR(250)
  ,@Mobile VARCHAR(15) 
  ,@OtherMobile VARCHAR(15) 
  ,@PhoneNo VARCHAR(50) 
  ,@CityId INT			
  ,@StateId INT			
  ,@GSTNo VARCHAR(30) 
  ,@OutwardRateType CHAR(1)		
  ,@FromCustCardNo INT			
  ,@ToCustCardNo INT			
  ,@BranchAccountId INT			
  ,@HOAccountId INT			
  ,@AllowedBankAccountId VARCHAR(200)
  ,@AllowedCardAccountId VARCHAR(200)
  ,@AllowedBankDaybookId VARCHAR(150)
  ,@AllowedCompanyId VARCHAR(120)
  ,@StockOutwardAccountId INT		    
  ,@StockInwardAccountId INT		    
  ,@TaxPayerTypeId INT		    
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Branches A Where A.BranchName = @BranchName AND A.StateId = @StateId)
  BEGIN
	SET @ErrorMessage = 'Branch name ' + @BranchName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Branches
  (	
	CompanyId 				
	,BranchName 			
	,BranchType 			
	,BranchVoucherNoPrefix  
	,Address 				
	,Mobile 				
	,OtherMobile 			
	,PhoneNo 				
	,CityId 				
	,StateId 				
	,GSTNo 					
	,OutwardRateType 		
	,FromCustCardNo 		
	,ToCustCardNo 			
	,BranchAccountId 		
	,HOAccountId 			
	,AllowedBankAccountId 	
	,AllowedCardAccountId 	
	,AllowedBankDaybookId 	
	,AllowedCompanyId 		
	,StockOutwardAccountId  
	,StockInwardAccountId 	
	,TaxPayerTypeId 		
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CompanyId 				
	,@BranchName 			
	,@BranchType 			
	,@BranchVoucherNoPrefix  
	,@Address 				
	,@Mobile 				
	,@OtherMobile 			
	,@PhoneNo 				
	,@CityId 				
	,@StateId 				
	,@GSTNo 					
	,@OutwardRateType 		
	,@FromCustCardNo 		
	,@ToCustCardNo 			
	,@BranchAccountId 		
	,@HOAccountId 			
	,@AllowedBankAccountId 	
	,@AllowedCardAccountId 	
	,@AllowedBankDaybookId 	
	,@AllowedCompanyId 		
	,@StockOutwardAccountId  
	,@StockInwardAccountId 	
	,@TaxPayerTypeId 		
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