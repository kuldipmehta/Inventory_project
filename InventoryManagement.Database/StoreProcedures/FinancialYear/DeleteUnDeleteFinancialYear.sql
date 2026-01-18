-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Deletes/UnDelete a Financial Year.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteFinancialYear]
(
  @FinancialYearId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set FinancialYear Deleted state.
  UPDATE
    dbo.FinancialYears
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    FinancialYearId = @FinancialYearId
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