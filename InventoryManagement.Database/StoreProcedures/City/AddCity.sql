-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Insert a new City.
-- =============================================
CREATE PROCEDURE [dbo].[AddCity]
  @CityName VARCHAR(120)
  ,@StateId INT
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.City A Where A.CityName = @CityName AND A.StateId = @StateId)
  BEGIN
	SET @ErrorMessage = 'City name ' + @CityName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.City
  (
	CityName
	,StateId
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CityName
	,@StateId
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