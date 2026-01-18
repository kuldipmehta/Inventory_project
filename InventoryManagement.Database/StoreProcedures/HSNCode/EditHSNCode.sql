-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Edit a HSN Code.
-- =============================================
CREATE PROCEDURE [dbo].[EditHSNCode]
(
  @HSNCodeId INT			 
  ,@HSNCode VARCHAR(30)	 
  ,@HSNDetail VARCHAR(MAX) 
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@HSNTaxType dbo.HSNTaxType READONLY
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.HSNCodes HC Where HC.HSNCode = @HSNCode AND HC.HSNCodeId <> @HSNCodeId )
  BEGIN
	SET @ErrorMessage = 'HSN Code ' + @HSNCode + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.HSNCodes
  SET 
    HSNCode = @HSNCode 
	,HSNDetail = @HSNDetail
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    HSNCodeId = @HSNCodeId
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

  EXEC dbo.MergeHSNTax @HSNCodeId, @UpdatedBy, @HSNTaxType

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END