-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Style details
-- ========================================================
CREATE PROCEDURE [dbo].[GetStyleDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    S.StyleId
	,S.StyleName
	,S.ShortName
	,S.IsActive
	,S.CreatedBy
	,S.CreatedDate
	,S.BranchTransferd
	,S.Transfered
	,S.UpdatedBy
	,S.UpdatedDate
	,S.ChangeTimeStamp
  FROM
    dbo.Styles S
  WHERE
    S.IsActive = COALESCE(@IsActive,S.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

