-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 2/03/2019
-- Description : Returns the Brand details
-- ========================================================
CREATE PROCEDURE [dbo].[GetBrandDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  SELECT
    B.BrandId
	,B.BrandName
	,B.ShortName
	,B.SrNo
	,B.IsActive
	,B.CreatedBy
	,B.CreatedDate
	,B.BranchTransferd
	,B.Transfered
	,B.UpdatedBy
	,B.UpdatedDate
	,B.ChangeTimeStamp
  FROM
    dbo.Brands B
  WHERE
    B.IsActive = COALESCE(@IsActive,B.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

