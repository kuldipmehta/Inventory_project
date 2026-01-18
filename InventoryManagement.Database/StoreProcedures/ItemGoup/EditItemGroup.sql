-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Edit a ItemGroup.
-- =============================================
CREATE PROCEDURE [dbo].[EditItemGroup]
(
  @ItemGroupId INT
  ,@ItemGroupName VARCHAR(120)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.ItemGroups A Where A.ItemGroupName = @ItemGroupName AND A.ItemGroupId <> @ItemGroupId)
  BEGIN
	SET @ErrorMessage = 'Item Group name ' + @ItemGroupName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.ItemGroups
  SET 
    ItemGroupName = @ItemGroupName
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    ItemGroupId = @ItemGroupId 
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