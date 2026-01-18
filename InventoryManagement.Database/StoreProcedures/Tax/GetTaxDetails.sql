-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Tax details
-- ========================================================
CREATE PROCEDURE [dbo].[GetTaxDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
	T.TaxId		
	,T.TaxTypeId
	,TT.TaxTypeName
	,T.TaxName	
	,T.SGSTPrc	
	,T.CGSTPrc	
	,T.IGSTPrc	
	,T.SurchargePrc
	,TA.CompanyId		       
	,TA.SGSTInPutAccountId     
	,TA.CGSTInPutAccountId     
	,TA.IGSTInPutAccountId     
	,TA.SGSTOutPutAccountId    
	,TA.CGSTOutPutAccountId    
	,TA.IGSTOutPutAccountId    
	,TA.SGSTPayableAccountId   
	,TA.CGSTPayableAccountId   
	,TA.IGSTPayableAccountId   
	,TA.RCMSGSTPayableAccountId
	,TA.RCMCGSTPayableAccountId
	,TA.RCMIGSTPayableAccountId
	,TA.RCMInPutSGSTAccountId  
	,TA.RCMInPutCGSTAccountId  
	,TA.RCMInPutIGSTAccountId  
	,TA.RCMOutPutSGSTAccountId 
	,TA.RCMOutPutCGSTAccountId 
	,TA.RCMOutPutIGSTAccountId 
	,T.IsActive
	,T.CreatedBy
	,T.CreatedDate
	,T.BranchTransferd
	,T.Transfered
	,T.UpdatedBy
	,T.UpdatedDate
	,T.ChangeTimeStamp
  FROM
    dbo.Taxes T
  INNER JOIN dbo.TaxAccounts TA
	ON TA.TaxId = T.TaxId
  INNER JOIN dbo.TaxTypes TT
	ON TT.TaxTypeId = T.TaxTypeId
  WHERE
    T.IsActive = COALESCE(@IsActive,T.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

