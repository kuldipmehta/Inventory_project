-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Edit a Branch.
-- =============================================
CREATE PROCEDURE [dbo].[EditBranch]
(
  @BranchId INT
  ,@CompanyId INT			
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
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Branches A Where A.BranchName = @BranchName AND A.BranchId <> @BranchId)
  BEGIN
	SET @ErrorMessage = 'Branch name ' + @BranchName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Branches
  SET 
     CompanyId = @CompanyId 				
	,BranchName = @BranchName 			
	,BranchType = @BranchType 			
	,BranchVoucherNoPrefix  = @BranchVoucherNoPrefix  
	,Address = @Address 				
	,Mobile = @Mobile 				
	,OtherMobile = @OtherMobile 			
	,PhoneNo = @PhoneNo 				
	,CityId = @CityId 				
	,StateId = @StateId 				
	,GSTNo = @GSTNo 					
	,OutwardRateType = @OutwardRateType 		
	,FromCustCardNo = @FromCustCardNo 		
	,ToCustCardNo = @ToCustCardNo 			
	,BranchAccountId = @BranchAccountId 		
	,HOAccountId = @HOAccountId 			
	,AllowedBankAccountId = @AllowedBankAccountId 	
	,AllowedCardAccountId = @AllowedCardAccountId 	
	,AllowedBankDaybookId = @AllowedBankDaybookId 	
	,AllowedCompanyId = @AllowedCompanyId 		
	,StockOutwardAccountId = @StockOutwardAccountId  
	,StockInwardAccountId = @StockInwardAccountId 	
	,TaxPayerTypeId = @TaxPayerTypeId 		
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    BranchId = @BranchId 
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