-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 05/04/2019
-- Description : Deletes/UnDelete a Employee.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteEmployee]
(
  @EmployeeId AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set Employee Deleted state.
  UPDATE
    dbo.Employees
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    EmployeeId = @EmployeeId
    AND IsActive <> @IsActive
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