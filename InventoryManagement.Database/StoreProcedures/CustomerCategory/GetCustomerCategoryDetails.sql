-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Returns the Customer Category details
-- ========================================================
CREATE PROCEDURE [dbo].[GetCustomerCategoryDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.CustomerCategoryId
	,C.CustomerCategoryName
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.CustomerCategories C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

