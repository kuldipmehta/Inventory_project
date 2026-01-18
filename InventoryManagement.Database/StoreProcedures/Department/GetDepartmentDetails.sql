-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Returns the Department details
-- ========================================================
CREATE PROCEDURE [dbo].[GetDepartmentDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    D.DepartmentId
	,D.DepartmentName
	,D.IsActive
	,D.CreatedBy
	,D.CreatedDate
	,D.BranchTransferd
	,D.Transfered
	,D.UpdatedBy
	,D.UpdatedDate
	,D.ChangeTimeStamp
  FROM
    dbo.Departments D
  WHERE
    D.IsActive = COALESCE(@IsActive,D.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

