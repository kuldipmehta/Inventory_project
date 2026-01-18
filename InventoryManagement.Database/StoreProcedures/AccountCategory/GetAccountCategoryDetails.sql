-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 31/03/2019
-- Description : Returns the Account Category details
-- ========================================================
CREATE PROCEDURE [dbo].[GetAccountCategoryDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.AccountCategoryId
	,C.CategoryName
	,C.ShortCode
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.AccountCategories C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

