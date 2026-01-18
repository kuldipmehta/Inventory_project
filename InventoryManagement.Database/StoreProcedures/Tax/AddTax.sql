-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Insert a new Tax.
-- =============================================
CREATE PROCEDURE [dbo].[AddTax]
  @TaxTypeId INT			
  ,@TaxName VARCHAR(50) 
  ,@SGSTPrc FLOAT		
  ,@CGSTPrc FLOAT		
  ,@IGSTPrc FLOAT		
  ,@SurchargePrc FLOAT	
  ,@CompanyId INT
  ,@SGSTInPutAccountId INT
  ,@CGSTInPutAccountId INT
  ,@IGSTInPutAccountId INT
  ,@SGSTOutPutAccountId INT
  ,@CGSTOutPutAccountId INT
  ,@IGSTOutPutAccountId INT
  ,@SGSTPayableAccountId INT
  ,@CGSTPayableAccountId INT
  ,@IGSTPayableAccountId INT
  ,@RCMSGSTPayableAccountId INT
  ,@RCMCGSTPayableAccountId INT
  ,@RCMIGSTPayableAccountId INT
  ,@RCMInPutSGSTAccountId INT
  ,@RCMInPutCGSTAccountId INT
  ,@RCMInPutIGSTAccountId INT
  ,@RCMOutPutSGSTAccountId INT
  ,@RCMOutPutCGSTAccountId INT
  ,@RCMOutPutIGSTAccountId INT
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Taxes T Where T.TaxName = @TaxName)
  BEGIN
	SET @ErrorMessage = 'Tax name ' + @TaxName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Taxes
  (
	TaxTypeId
	,TaxName	
	,SGSTPrc	
	,CGSTPrc	
	,IGSTPrc	
	,SurchargePrc
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@TaxTypeId
	,@TaxName	
	,@SGSTPrc	
	,@CGSTPrc	
	,@IGSTPrc	
	,@SurchargePrc
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  DECLARE @TaxId INT = SCOPE_IDENTITY()

   -- Insert the New value.
  INSERT INTO dbo.TaxAccounts
  (
	CompanyId		        
	,TaxId			        
	,SGSTInPutAccountId     
	,CGSTInPutAccountId     
	,IGSTInPutAccountId     
	,SGSTOutPutAccountId    
	,CGSTOutPutAccountId    
	,IGSTOutPutAccountId    
	,SGSTPayableAccountId   
	,CGSTPayableAccountId   
	,IGSTPayableAccountId   
	,RCMSGSTPayableAccountId
	,RCMCGSTPayableAccountId
	,RCMIGSTPayableAccountId
	,RCMInPutSGSTAccountId  
	,RCMInPutCGSTAccountId  
	,RCMInPutIGSTAccountId  
	,RCMOutPutSGSTAccountId 
	,RCMOutPutCGSTAccountId 
	,RCMOutPutIGSTAccountId 
  )
  VALUES
  ( 
	@CompanyId		        
	,@TaxId			        
	,@SGSTInPutAccountId     
	,@CGSTInPutAccountId     
	,@IGSTInPutAccountId     
	,@SGSTOutPutAccountId    
	,@CGSTOutPutAccountId    
	,@IGSTOutPutAccountId    
	,@SGSTPayableAccountId   
	,@CGSTPayableAccountId   
	,@IGSTPayableAccountId   
	,@RCMSGSTPayableAccountId
	,@RCMCGSTPayableAccountId
	,@RCMIGSTPayableAccountId
	,@RCMInPutSGSTAccountId  
	,@RCMInPutCGSTAccountId  
	,@RCMInPutIGSTAccountId  
	,@RCMOutPutSGSTAccountId 
	,@RCMOutPutCGSTAccountId 
	,@RCMOutPutIGSTAccountId 
  )


  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END