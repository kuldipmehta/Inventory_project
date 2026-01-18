-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Edit a Tax.
-- =============================================
CREATE PROCEDURE [dbo].[EditTax]
(
  @TaxId INT
  ,@TaxTypeId INT			
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
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Taxes T Where T.TaxName = @TaxName AND T.TaxId <> @TaxId)
  BEGIN
	SET @ErrorMessage = 'Tax name ' + @TaxName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Taxes
  SET 
    TaxTypeId = @TaxTypeId
	,TaxName = @TaxName	
	,SGSTPrc = @SGSTPrc	
	,CGSTPrc = @CGSTPrc	
	,IGSTPrc = @IGSTPrc	
	,SurchargePrc = @SurchargePrc
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    TaxId = @TaxId 
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

  -- Edit details.
  UPDATE 
    dbo.TaxAccounts
  SET 
    CompanyId		        = @CompanyId		       
	,TaxId			        = @TaxId			       
	,SGSTInPutAccountId      = @SGSTInPutAccountId     
	,CGSTInPutAccountId      = @CGSTInPutAccountId     
	,IGSTInPutAccountId      = @IGSTInPutAccountId     
	,SGSTOutPutAccountId     = @SGSTOutPutAccountId    
	,CGSTOutPutAccountId     = @CGSTOutPutAccountId    
	,IGSTOutPutAccountId     = @IGSTOutPutAccountId    
	,SGSTPayableAccountId    = @SGSTPayableAccountId   
	,CGSTPayableAccountId    = @CGSTPayableAccountId   
	,IGSTPayableAccountId    = @IGSTPayableAccountId   
	,RCMSGSTPayableAccountId = @RCMSGSTPayableAccountId
	,RCMCGSTPayableAccountId = @RCMCGSTPayableAccountId
	,RCMIGSTPayableAccountId = @RCMIGSTPayableAccountId
	,RCMInPutSGSTAccountId   = @RCMInPutSGSTAccountId  
	,RCMInPutCGSTAccountId   = @RCMInPutCGSTAccountId  
	,RCMInPutIGSTAccountId   = @RCMInPutIGSTAccountId  
	,RCMOutPutSGSTAccountId  = @RCMOutPutSGSTAccountId 
	,RCMOutPutCGSTAccountId  = @RCMOutPutCGSTAccountId 
	,RCMOutPutIGSTAccountId  = @RCMOutPutIGSTAccountId 
  WHERE 
    TaxId = @TaxId 

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