-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Company details
-- ========================================================
CREATE PROCEDURE [dbo].[GetCompanyDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.CompanyId	
	,C.CompanyName	   
    ,C.SubCompanyName
    ,C.ShortName	   
    ,C.BusinessTypeId
	,B.BusinessTypeName
    ,C.Address
	,C.CityId
	,CI.CityName
    ,C.StateId
	,S.StateName
    ,C.Pincode
    ,C.PhoneNo
    ,C.MobileNo
    ,C.EmailId
    ,C.WebSite
    ,C.GSTNo		   
    ,C.PANNO		   
    ,C.JurisDiction	   
    ,C.CurrentBranchId   
    ,C.WithOutBarcodeOption
    ,C.CompositionScheme
    ,C.TaxPayerTypeId
	,C.CompanyTypeId
	,CT.CompanyTypeName
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.Companies C
  LEFT JOIN dbo.[City] CI
	ON C.CityId = CI.CityId
  LEFT JOIN dbo.[State] S
	ON C.StateId = S.StateId
  LEFT JOIN dbo.BusinessTypes B
	ON C.BusinessTypeId = B.BusinessTypeId
  LEFT JOIN dbo.CompanyTypes CT
	ON C.CompanyTypeId = CT.CompanyTypeId
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

