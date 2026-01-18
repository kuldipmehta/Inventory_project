-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Returns the ItemGroup details
-- ========================================================
CREATE PROCEDURE [dbo].[GetItemGroupDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.ItemGroupId
	,C.ItemGroupName
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.ItemGroups C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

