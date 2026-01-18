-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 28/03/2019
-- Description : Synchronizes the Size Countries master.
-- ========================================================
CREATE PROCEDURE [dbo].[MergeSizeGroupSizes]
  @SizeGroupId INT
  ,@UpdatedBy TINYINT
  ,@SizeGroupSizeType dbo.SizeGroupSizeType READONLY
AS
BEGIN 
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  --Merge the Permissions Details.	
	MERGE
		dbo.SizeGroupSizes
	AS T
	USING (SELECT 
			@SizeGroupId AS SizeGroupId
			,SizeShortName
			,SrNo	
         FROM 
          @SizeGroupSizeType) AS S
		ON T.SrNo = S.SrNo
	       AND T.SizeGroupId= S.SizeGroupId
	WHEN NOT MATCHED BY TARGET THEN --Insert Rows.
	INSERT 
	(
		[SizeGroupId]	
		,[SizeShortName]		
		,[SrNo]					
		,[CreatedBy]			
		,[CreatedDate]		
		,[UpdatedBy]			
		,[UpdatedDate]
	) 
	VALUES
	(
		SizeGroupId	
		,SizeShortName
		,SrNo
		,@UpdatedBy		
		,@CurrentDate
		,@UpdatedBy
		,@CurrentDate
	)
	WHEN MATCHED THEN --Update Rows.
	UPDATE
	SET
		
		T.SizeShortName = S.SizeShortName
		,T.UpdatedBy	= @UpdatedBy
		,T.UpdatedDate  = GETDATE()
	WHEN NOT MATCHED BY SOURCE AND T.SizeGroupId = @SizeGroupId  THEN --Delete Rows.
	DELETE;

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END