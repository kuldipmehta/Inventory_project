-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Insert a new HSNCode.
-- =============================================
CREATE PROCEDURE [dbo].[AddHSNCode]
  @HSNCode VARCHAR(30)	 
  ,@HSNDetail VARCHAR(MAX) 
  ,@CreatedBy INT
  ,@HSNTaxType dbo.HSNTaxType READONLY
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.HSNCodes HC Where HC.HSNCode = @HSNCode)
  BEGIN
	SET @ErrorMessage = 'HSN Code ' + @HSNCode + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.HSNCodes
  (
	HSNCode
	,HSNDetail
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@HSNCode
	,@HSNDetail
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  DECLARE @HSNCodeId INT = SCOPE_IDENTITY()

  EXEC dbo.MergeHSNTax @HSNCodeId, @CreatedBy, @HSNTaxType

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END