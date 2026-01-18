-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Returns the Financial Year details
-- ========================================================
CREATE PROCEDURE [dbo].[GetFinancialYearDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    FY.FinancialYearId
	,FY.OpeningDate
	,FY.ClosingDate
	,FY.YearCode
	,FY.IsActive
	,FY.CreatedBy
	,FY.CreatedDate
	,FY.Transfered
	,FY.UpdatedBy
	,FY.UpdatedDate
	,FY.ChangeTimeStamp
  FROM
    dbo.FinancialYears FY
  WHERE
    FY.IsActive = COALESCE(@IsActive,FY.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

