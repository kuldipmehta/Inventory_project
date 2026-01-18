-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Edit a SizeGroup.
-- =============================================
CREATE PROCEDURE [dbo].[EditSizeGroup]
(
  @SizeGroupId INT
  ,@SizeGroupName VARCHAR(30)
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@SizeGroupSizeType dbo.SizeGroupSizeType READONLY
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.SizeGroups A Where A.SizeGroupName = @SizeGroupName AND A.SizeGroupId <> @SizeGroupId)
  BEGIN
	SET @ErrorMessage = 'Size Group ' + @SizeGroupName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.SizeGroups
  SET 
    SizeGroupName = @SizeGroupName
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    SizeGroupId = @SizeGroupId 
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

  EXEC dbo.MergeSizeGroupSizes @SizeGroupId, @UpdatedBy, @SizeGroupSizeType

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END