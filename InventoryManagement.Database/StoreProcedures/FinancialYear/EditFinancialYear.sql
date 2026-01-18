-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Edit a FinancialYear.
-- =============================================
CREATE PROCEDURE [dbo].[EditFinancialYear]
(
  @FinancialYearId INT
  ,@YearCode VARCHAR(10) 
  ,@OpeningDate DATETIME	
  ,@ClosingDate DATETIME
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.FinancialYears FY WHERE FY.YearCode = @YearCode AND FY.FinancialYearId <> @FinancialYearId)
  BEGIN
	SET @ErrorMessage = 'Year Code ' + @YearCode + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.FinancialYears
  SET 
    OpeningDate = @OpeningDate
	,ClosingDate = @ClosingDate
	,YearCode = @YearCode
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    FinancialYearId = @FinancialYearId 
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