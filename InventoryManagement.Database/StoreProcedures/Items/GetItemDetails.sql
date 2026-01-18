-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Returns the Item details
-- ========================================================
CREATE PROCEDURE [dbo].[GetItemDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    I.ItemId
	,I.CompanyId
	,I.BranchId
	,I.DepartmentId
	,D.DepartmentName
	,I.BrandId  
	,B.BrandName
	,I.ProductId
	,P.ProductName
	,I.StyleId
	,S.StyleName
	,I.GroupId
	,IG.ItemGroupName AS GroupName
	,I.ItemName
	,I.ShortName
	,I.BarcodeType
	,I.ItemShortcut
	,I.DefaultQty  
	,I.HSNCode
	,I.DayBookType
	,I.ItemWiseMargin	
	,I.IsActive
	,I.CreatedBy
	,I.CreatedDate
	,I.BranchTransferd
	,I.Transfered
	,I.UpdatedBy
	,I.UpdatedDate
	,I.ChangeTimeStamp
  FROM
    dbo.Items I
  LEFT JOIN dbo.Departments D
	ON D.DepartmentId = I.DepartmentId
  LEFT JOIN dbo.Brands B
	ON B.BrandId = I.BrandId
  LEFT JOIN dbo.Styles S
	ON S.StyleId = I.StyleId
  LEFT JOIN dbo.ItemGroups IG
	ON IG.ItemGroupId = I.GroupId
  LEFT JOIN dbo.Products P
	ON P.ProductId = I.ProductId
  WHERE
    I.IsActive = COALESCE(@IsActive,I.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

