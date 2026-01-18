-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 28/03/2019
-- Description : Synchronizes the Size Countries master.
-- ========================================================
CREATE PROCEDURE [dbo].[MergeSizeCountries]
  @ShortName AS VARCHAR(25)  
  ,@UpdatedBy TINYINT
  ,@SizeCountryType dbo.SizeCountryType READONLY
AS
BEGIN 
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  --Merge the Permissions Details.	
	MERGE
		dbo.SizeCountries
	AS T
	USING (SELECT 
			@ShortName AS ShortName
			,SizeDepartmentId
			,USSizeShortName	
			,EuropSizeShortName
			,LengthCM			
			,LengthInch		
         FROM 
          @SizeCountryType) AS S
		ON T.SizeShortName = S.ShortName 
	       AND T.SizeDepartmentId= S.SizeDepartmentId
	WHEN NOT MATCHED BY TARGET THEN --Insert Rows.
	INSERT 
	(
		[SizeShortName]		
		,[SizeDepartmentId]	
		,[USSizeShortName]	
		,[EuropSizeShortName]
		,[LengthCM]			
		,[LengthInch]		
		,[CreatedBy]			
		,[CreatedDate]		
		,[UpdatedBy]			
		,[UpdatedDate]
	) 
	VALUES
	(
		ShortName	
		,SizeDepartmentId
		,USSizeShortName
		,EuropSizeShortName
		,LengthCM			
		,LengthInch
		,@UpdatedBy		
		,@CurrentDate
		,@UpdatedBy
		,@CurrentDate
	)
	WHEN MATCHED THEN --Update Rows.
	UPDATE
	SET
		T.USSizeShortName	   = S.USSizeShortName 
		,T.EuropSizeShortName  = S.EuropSizeShortName
		,T.LengthCM			   = S.LengthCM			  
		,T.LengthInch	       = S.LengthInch
		,T.UpdatedBy		   = @UpdatedBy
		,T.UpdatedDate         = GETDATE()
	WHEN NOT MATCHED BY SOURCE AND T.SizeShortName = @ShortName  THEN --Delete Rows.
	DELETE;

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END