-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Deletes/UnDelete a Company.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteCompany]
(
  @CompanyId AS INT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set Company Deleted state.
  UPDATE
    dbo.Companies
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    CompanyId = @CompanyId
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