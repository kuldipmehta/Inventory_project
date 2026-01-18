-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Branch details
-- ========================================================
CREATE PROCEDURE [dbo].[GetBranchDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    B.BranchId
	,B.CompanyId
	,B.BranchName
	,B.BranchType
	,B.BranchVoucherNoPrefix
	,B.Address
	,B.Mobile
	,B.OtherMobile
	,B.PhoneNo
	,B.CityId
	,B.StateId
	,B.GSTNo			
	,B.OutwardRateType
	,B.FromCustCardNo
	,B.ToCustCardNo
	,B.BranchAccountId
	,B.HOAccountId
	,B.AllowedBankAccountId
	,B.AllowedCardAccountId
	,B.AllowedBankDaybookId
	,B.AllowedCompanyId
	,B.StockOutwardAccountId
	,B.StockInwardAccountId
	,B.TaxPayerTypeId
	,S.StateName
	,B.IsActive
	,B.CreatedBy
	,B.CreatedDate
	,B.BranchTransferd
	,B.Transfered
	,B.UpdatedBy
	,B.UpdatedDate
	,B.ChangeTimeStamp
  FROM
    dbo.Branches B
  LEFT JOIN dbo.[State] S
	ON B.StateId= S.StateId
  WHERE
    B.IsActive = COALESCE(@IsActive,B.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

