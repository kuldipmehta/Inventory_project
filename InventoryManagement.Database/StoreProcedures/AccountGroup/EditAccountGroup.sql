-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Edit a AccountGroup.
-- =============================================
CREATE PROCEDURE [dbo].[EditAccountGroup]
(
  @GroupId INT
  ,@GroupIdManual INT
  ,@GroupName VARCHAR(120)
  ,@GroupTypeId INT
  ,@AccountTransferToBranch Bit
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.AccountGroups A Where A.GroupName = @GroupName AND A.GroupId <> @GroupId)
  BEGIN
	SET @ErrorMessage = 'Group name ' + @GroupName + ' already exists.'
	RETURN 1001;
  END

    IF EXISTS(SELECT 1 FROM dbo.AccountGroups A Where A.GroupIdManual = @GroupIdManual AND A.GroupId <> @GroupId)
  BEGIN
	SET @ErrorMessage = 'Group Id ' + @GroupIdManual  + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.AccountGroups
  SET 
	GroupIdManual = @GroupIdManual
    ,GroupName = @GroupName
	,GroupTypeId = @GroupTypeId
	,AccountTransferToBranch = @AccountTransferToBranch
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    GroupId = @GroupId 
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