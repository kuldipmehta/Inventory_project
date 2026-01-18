-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 30/03/2019
-- Description : Synchronizes the HSn tax
-- ========================================================
CREATE PROCEDURE [dbo].[MergeHSNTax]
  @HSNCodeId INT
  ,@UpdatedBy TINYINT
  ,@HSNTaxType dbo.HSNTaxType READONLY
AS
BEGIN 
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  --Merge the Permissions Details.	
	MERGE
		dbo.HSNTaxes
	AS T
	USING (SELECT 
			@HSNCodeId AS HSNCodeId
			,TaxId	  
			,FromDate
			,ToDate
			,FromRate
			,ToRate 
			,FromPurcRate
			,ToPurcRate
         FROM 
          @HSNTaxType) AS S
		ON T.HSNCodeId = S.HSNCodeId
	       AND T.TaxId= S.TaxId
	WHEN NOT MATCHED BY TARGET THEN --Insert Rows.
	INSERT 
	(
		[HSNCodeId]  
		,[TaxId]		 
		,[FromDate]   
		,[ToDate]     
		,[FromRate]   
		,[ToRate]     
		,[FromPurcRate]
		,[ToPurcRate] 
		,[CreatedBy]			
		,[CreatedDate]		
		,[UpdatedBy]			
		,[UpdatedDate]
	) 
	VALUES
	(
		HSNCodeId
		,TaxId	 
		,FromDate
		,ToDate    
		,FromRate
		,ToRate    
		,FromPurcRate
		,ToPurcRate
		,@UpdatedBy		
		,@CurrentDate
		,@UpdatedBy
		,@CurrentDate
	)
	WHEN MATCHED THEN --Update Rows.
	UPDATE
	SET
		
		T.FromDate = s.FromDate
		,T.ToDate = s.ToDate    
		,T.FromRate = s.FromRate
		,T.ToRate = s.ToRate    
		,T.FromPurcRate = s.FromPurcRate
		,T.ToPurcRate = s.ToPurcRate
		,T.UpdatedBy = @UpdatedBy
		,T.UpdatedDate = GETDATE()
	WHEN NOT MATCHED BY SOURCE AND T.HSNCodeId = @HSNCodeId THEN --Delete Rows.
	DELETE;

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END