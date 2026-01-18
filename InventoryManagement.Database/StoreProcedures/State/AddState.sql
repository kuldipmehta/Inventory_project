-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Insert a new State.
-- =============================================
CREATE PROCEDURE [dbo].[AddState]
  @StateName VARCHAR(100)
  ,@StateCode VARCHAR(50)
  ,@CountryId INT
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.State S Where S.StateName = @StateName AND S.CountryId = @CountryId)
  BEGIN
	SET @ErrorMessage = 'State name ' + @StateName + ' already exists.'
	RETURN 1001;
  END

  --Insert the New value.
  INSERT INTO dbo.[State]
  (
	StateName
	,StateCode
	,CountryId
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@StateName
	,@StateCode
	,@CountryId 
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