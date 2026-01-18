-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 05/04/2019
-- Description : Returns the Employee Department details
-- ========================================================
CREATE PROCEDURE [dbo].[GetEmployeeDepartmentDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.EmployeeDepartmentId
	,C.DepartmentName
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.EmployeeDepartments C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

