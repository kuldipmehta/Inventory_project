-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Returns the Product details
-- ========================================================
CREATE PROCEDURE [dbo].[GetProductDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    P.ProductId
	,P.ProductName
	,P.ShortName			
	,P.SizeGroupId
	,P.MeasurementTypeId
	,PS.ProductNames
	,P.IsActive
	,P.CreatedBy
	,P.CreatedDate
	,P.BranchTransferd
	,P.Transfered
	,P.UpdatedBy
	,P.UpdatedDate
	,P.ChangeTimeStamp
  FROM
    dbo.Products P  
 OUTER APPLY
  ( 
    SELECT ProductNames =
      STUFF((SELECT
				',' + CONVERT(VARCHAR,PS.SizeShortName)
			FROM 
				dbo.ProductSizes PS
	        WHERE
				PS.ProductId = P.ProductId
			FOR XML PATH('')),
		1,1,'')
  ) PS
  WHERE
    P.IsActive = COALESCE(@IsActive,P.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

