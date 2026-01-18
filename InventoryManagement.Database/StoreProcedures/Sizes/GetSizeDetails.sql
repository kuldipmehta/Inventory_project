-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Returns the Size details
-- ========================================================
CREATE PROCEDURE [dbo].[GetSizeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    S.SizeId
	,S.SizeName
	,S.ShortName
	,S.SrNo
	,S.IsActive
	,S.CreatedBy
	,S.CreatedDate
	,S.BranchTransferd
	,S.Transfered
	,S.UpdatedBy
	,S.UpdatedDate
	,S.ChangeTimeStamp
  FROM
    dbo.Sizes S
  WHERE
    S.IsActive = COALESCE(@IsActive,S.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

