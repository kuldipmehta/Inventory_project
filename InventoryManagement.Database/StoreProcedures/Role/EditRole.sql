-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Edit a Role.
-- =============================================
CREATE PROCEDURE [dbo].[EditRole]
(
  @Id INT
  ,@Name VARCHAR(256)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;
	
	 IF EXISTS(SELECT 1 FROM dbo.ApplicationRole A Where A.Name = @Name AND A.Id <> @Id)
	 BEGIN
	 	SET @ErrorMessage = 'Role name ' + @Name + ' already exists.'
	 	RETURN 1001;
	 END

	-- Edit details.
	UPDATE 
	  [dbo].ApplicationRole
	SET 
	  Name = @Name
	  ,NormalizedName = UPPER(@Name)
	  ,UpdatedBy = @UpdatedBy
	  ,UpdatedDate  = GETDATE()
	WHERE 
	  Id = @Id 
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