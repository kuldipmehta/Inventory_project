-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Edit a Department.
-- =============================================
CREATE PROCEDURE [dbo].[EditDepartment]
(
  @DepartmentId INT
  ,@DepartmentName VARCHAR(60)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Departments A Where A.DepartmentName = @DepartmentName AND A.DepartmentId <> @DepartmentId)
  BEGIN
	SET @ErrorMessage = 'Department name ' + @DepartmentName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Departments
  SET 
    DepartmentName = @DepartmentName
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    DepartmentId = @DepartmentId 
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END