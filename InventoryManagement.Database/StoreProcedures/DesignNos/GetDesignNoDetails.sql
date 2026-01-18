-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Returns the Design No details
-- ========================================================
CREATE PROCEDURE [dbo].[GetDesignNoDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    D.DesignNoId
	,D.CompanyId
	,D.BranchId
	,D.DesignNo
	,D.ItemId
	,I.ItemName
	,D.PurchaseRate
	,D.SalesRate
	,D.MRP
	,D.WhSalesRate
	,D.WhSalesRate2
	,D.MinStockQty
	,D.MaxStockQty
	,D.Remarks
	,D.IsActive
	,D.CreatedBy
	,D.CreatedDate
	,D.BranchTransferd
	,D.Transfered
	,D.UpdatedBy
	,D.UpdatedDate
	,D.ChangeTimeStamp
  FROM
    dbo.DesignNos D
  LEFT JOIN dbo.Items I
	ON I.ItemId = D.ItemId
  WHERE
    D.IsActive = COALESCE(@IsActive,D.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

