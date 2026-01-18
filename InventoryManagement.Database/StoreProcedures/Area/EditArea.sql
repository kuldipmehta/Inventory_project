-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Edit a Area.
-- =============================================
CREATE PROCEDURE [dbo].[EditArea]
(
  @AreaId INT
  ,@AreaName VARCHAR(100)
  ,@PinCode VARCHAR(10) 
  ,@CityId INT 
  ,@RegionCode VARCHAR(5) 
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;
	
	 IF EXISTS(SELECT 1 FROM dbo.Area A Where A.AreaName = @AreaName AND A.CityId = @CityId AND A.AreaId <> @AreaId)
	 BEGIN
	 	SET @ErrorMessage = 'Area name ' + @AreaName + ' already exists.'
	 	RETURN 1001;
	 END

	IF EXISTS(SELECT 1 FROM dbo.Area A Where A.RegionCode = @RegionCode AND A.AreaId <> @AreaId)
	BEGIN
		SET @ErrorMessage = 'Region code ' + @RegionCode + ' already exists.'
		RETURN 1001;
	END

	-- Edit details.
	UPDATE 
	  [dbo].Area
	SET 
	  AreaName = @AreaName
		,PinCode = @PinCode
		,CityId = @CityId
		,RegionCode = @RegionCode
	    ,UpdatedBy = @UpdatedBy
	    ,UpdatedDate  = GETDATE()
	WHERE 
	  AreaId = @AreaId 
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