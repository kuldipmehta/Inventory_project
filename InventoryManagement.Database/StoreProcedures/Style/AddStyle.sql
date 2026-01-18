-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Insert a new Style.
-- =============================================
CREATE PROCEDURE [dbo].[AddStyle]
  @StyleName VARCHAR(60)
  ,@ShortName VARCHAR(15)
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Styles A Where A.StyleName = @StyleName)
  BEGIN
	SET @ErrorMessage = 'Style name ' + @StyleName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Styles A Where A.ShortName= @ShortName)
  BEGIN
	SET @ErrorMessage = 'Short name ' + @ShortName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Styles
  (
	StyleName
	,ShortName
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@StyleName
	,@ShortName
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