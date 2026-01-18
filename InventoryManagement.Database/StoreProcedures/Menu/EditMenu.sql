-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Edit a Menu.
-- =============================================
CREATE PROCEDURE [dbo].[EditMenu]
(
  @MenuId INT
  ,@MenuName VARCHAR(120)
  ,@DisplayName VARCHAR(120)
  ,@Type VARCHAR(50)
  ,@Url VARCHAR(120)
  ,@Icon VARCHAR(50)
  ,@ParentId INT 
  ,@Permissions VARCHAR(500)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;
	
	 IF EXISTS(SELECT 1 FROM dbo.Menu A Where A.MenuName = @MenuName AND A.MenuId <> @MenuId)
	 BEGIN
	 	SET @ErrorMessage = 'Menu name ' + @MenuName + ' already exists.'
	 	RETURN 1001;
	 END

	-- Edit details.
	UPDATE 
	  [dbo].Menu
	SET 
	  MenuName = @MenuName
	  ,DisplayName = @DisplayName   
 	  ,[Type] = @Type		  
	  ,[Url] = @Url		  
	  ,Icon = @Icon		  
	  ,ParentId = @ParentId	  
	  ,[Permissions] = @Permissions 
	  ,UpdatedBy = @UpdatedBy
	  ,UpdatedDate  = GETDATE()
	WHERE 
	  MenuId = @MenuId 
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