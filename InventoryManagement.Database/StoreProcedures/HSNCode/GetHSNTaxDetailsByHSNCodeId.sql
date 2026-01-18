-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Returns the HSN tax details by HSN Code Id details
-- ========================================================
CREATE PROCEDURE [dbo].[GetHSNTaxDetailsByHSNCodeId]
  @HSNCodeId AS INT = 0
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
	HT.HSNCodeId
	,T.TaxId	   
	,T.TaxName
	,HT.FromDate
	,HT.ToDate
	,HT.FromRate
	,HT.ToRate  
	,HT.FromPurcRate
	,HT.ToPurcRate
	,HT.IsActive
	,HT.CreatedBy
	,HT.CreatedDate
	,HT.BranchTransferd
	,HT.Transfered
	,HT.UpdatedBy
	,HT.UpdatedDate
	,HT.ChangeTimeStamp
  FROM
	dbo.Taxes T
  LEFT JOIN dbo.HSNTaxes HT
	ON HT.TaxId = T.TaxId
	AND HT.HSNCodeId = @HSNCodeId
  WHERE
	@HSNCodeId = 0
    OR HT.HSNCodeId = @HSNCodeId

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

