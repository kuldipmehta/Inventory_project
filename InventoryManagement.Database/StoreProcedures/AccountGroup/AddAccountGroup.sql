-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Insert a new AccountGroup.
-- =============================================
CREATE PROCEDURE [dbo].[AddAccountGroup]
  @GroupIdManual INT
  ,@GroupName VARCHAR(120)
  ,@GroupTypeId INT
  ,@AccountTransferToBranch Bit
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.AccountGroups A Where A.GroupIdManual = @GroupIdManual)
  BEGIN
	SET @ErrorMessage = 'Group Id ' + @GroupIdManual + ' already exists.'
	RETURN 1001;
  END


  IF EXISTS(SELECT 1 FROM dbo.AccountGroups A Where A.GroupName = @GroupName)
  BEGIN
	SET @ErrorMessage = 'Group name ' + @GroupName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.AccountGroups
  (
	GroupIdManual
	,GroupName
	,GroupTypeId
	,AccountTransferToBranch
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (  
	@GroupIdManual
	,@GroupName
    ,@GroupTypeId
	,@AccountTransferToBranch
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