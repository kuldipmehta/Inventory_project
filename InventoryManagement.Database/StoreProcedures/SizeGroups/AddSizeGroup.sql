-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Insert a new Size Group.
-- =============================================
CREATE PROCEDURE [dbo].[AddSizeGroup]
  @SizeGroupName VARCHAR(30)
  ,@CreatedBy INT
  ,@SizeGroupSizeType dbo.SizeGroupSizeType READONLY
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.SizeGroups SG Where SG.SizeGroupName = @SizeGroupName)
  BEGIN
	SET @ErrorMessage = 'Size Group ' + @SizeGroupName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.SizeGroups
  (
	SizeGroupName
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@SizeGroupName
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  DECLARE @SizeGroupId INT = SCOPE_IDENTITY()

  EXEC dbo.MergeSizeGroupSizes @SizeGroupId, @CreatedBy, @SizeGroupSizeType

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END