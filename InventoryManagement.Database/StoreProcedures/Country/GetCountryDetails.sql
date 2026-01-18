-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Country details
-- ========================================================
CREATE PROCEDURE [dbo].[GetCountryDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.CountryId
	,C.CountryName
	,C.CountryCode
	,C.MobileFixCode
	,C.CurrencyRate 
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.Country C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

