-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Returns the Size Group Size details
-- ========================================================
CREATE PROCEDURE [dbo].[GetSizeGroupSizeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    SGS.SizeGroupSizeId
	,SGS.SizeGroupId
	,SGS.SizeShortName
	,SGS.SrNo
	,SGS.IsActive
	,SGS.CreatedBy
	,SGS.CreatedDate
	,SGS.BranchTransferd
	,SGS.Transfered
	,SGS.UpdatedBy
	,SGS.UpdatedDate
	,SGS.ChangeTimeStamp
  FROM
    dbo.SizeGroupSizes SGS
  WHERE
    SGS.IsActive = COALESCE(@IsActive, SGS.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

