-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Edit a State.
-- =============================================
CREATE PROCEDURE [dbo].[EditState]
(
  @StateId INT
  ,@StateName VARCHAR(100)
  ,@StateCode VARCHAR(50)
  ,@CountryId INT
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
   SET NOCOUNT ON;
	
  IF EXISTS(SELECT 1 FROM dbo.State S Where S.StateName = @StateName AND S.CountryId = @CountryId AND S.StateId <> @StateId)
  BEGIN
	SET @ErrorMessage = 'State name ' + @StateName + ' already exists.'
	RETURN 1001;
  END

  -- Edit details.
  UPDATE 
    [dbo].State
  SET 
    StateName = @StateName
	,StateCode = @StateCode 
	,CountryId = @CountryId
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate  = GETDATE()
  WHERE 
    StateId = @StateId 
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