-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Returns the HSN Code details
-- ========================================================
CREATE PROCEDURE [dbo].[GetHSNCodeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
	HC.HSNCodeId
    ,HC.HSNCode
	,HC.HSNDetail
	,HC.IsActive
	,HC.CreatedBy
	,HC.CreatedDate
	,HC.BranchTransferd
	,HC.Transfered
	,HC.UpdatedBy
	,HC.UpdatedDate
	,HC.ChangeTimeStamp
  FROM
    dbo.HSNCodes HC
  WHERE
    HC.IsActive = COALESCE(@IsActive,HC.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

