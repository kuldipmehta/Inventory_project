-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Returns the Color details
-- ========================================================
CREATE PROCEDURE [dbo].[GetColorDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  SELECT
    C.ColorId
	,C.ColorName
	,C.SrNo
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.Colors C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

