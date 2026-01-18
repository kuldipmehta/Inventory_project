-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 05/04/2019
-- Description : Returns the Employee Designation details
-- ========================================================
CREATE PROCEDURE [dbo].[GetEmployeeDesignationDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    ED.DesignationId
	,ED.Designation
	,ED.IsActive
	,ED.CreatedBy
	,ED.CreatedDate
	,ED.BranchTransferd
	,ED.UpdatedBy
	,ED.UpdatedDate
	,ED.ChangeTimeStamp
  FROM
    dbo.EmployeeDesignations ED
  WHERE
    ED.IsActive = COALESCE(@IsActive,ED.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

