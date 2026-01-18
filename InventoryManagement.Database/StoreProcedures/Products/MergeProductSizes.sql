-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 28/03/2019
-- Description : Synchronizes the Size Countries master.
-- ========================================================
CREATE PROCEDURE [dbo].[MergeProductSizes]
  @ProductId INT
  ,@UpdatedBy TINYINT
  ,@ProductSizeType dbo.ProductSizeType READONLY
AS
BEGIN 
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  --Merge the Permissions Details.	
	MERGE
		dbo.ProductSizes
	AS T
	USING (SELECT 
			@ProductId AS ProductId
			,SizeShortName
			,SrNo	
         FROM 
          @ProductSizeType) AS S
		ON T.SrNo = S.SrNo
	       AND T.ProductId= S.ProductId
	WHEN NOT MATCHED BY TARGET THEN --Insert Rows.
	INSERT 
	(
		[ProductId]	
		,[SizeShortName]		
		,[SrNo]					
		,[CreatedBy]			
		,[CreatedDate]		
		,[UpdatedBy]			
		,[UpdatedDate]
	) 
	VALUES
	(
		ProductId	
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
	WHEN NOT MATCHED BY SOURCE AND T.ProductId = @ProductId  THEN --Delete Rows.
	DELETE;

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END