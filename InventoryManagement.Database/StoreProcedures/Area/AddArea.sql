-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Insert a new Area.
-- =============================================
CREATE PROCEDURE [dbo].[AddArea]
  @AreaName VARCHAR(100)
  ,@PinCode VARCHAR(10) 
  ,@CityId INT 
  ,@RegionCode VARCHAR(5) 
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Area A Where A.AreaName = @AreaName AND A.CityId = @CityId)
  BEGIN
	SET @ErrorMessage = 'Area name ' + @AreaName + ' already exists.'
	RETURN 1001;
  END

  IF EXISTS(SELECT 1 FROM dbo.Area A Where A.RegionCode = @RegionCode)
  BEGIN
	SET @ErrorMessage = 'Region code ' + @RegionCode + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Area
  (
	AreaName
	,PinCode
	,CityId
	,RegionCode
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@AreaName
	,@PinCode
	,@CityId
	,@RegionCode
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