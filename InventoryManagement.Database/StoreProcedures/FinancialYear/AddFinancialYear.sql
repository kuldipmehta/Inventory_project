-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Insert a new Financial Year.
-- =============================================
CREATE PROCEDURE [dbo].[AddFinancialYear]
  @YearCode VARCHAR(10) 
  ,@OpeningDate DATETIME	
  ,@ClosingDate DATETIME	
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.FinancialYears FY Where FY.YearCode = @YearCode)
  BEGIN
	SET @ErrorMessage = 'Year Code ' + @YearCode + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.FinancialYears
  (
	OpeningDate
	,ClosingDate
	,YearCode
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@OpeningDate
	,@ClosingDate
	,@YearCode
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END