-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Insert a new Product.
-- =============================================
CREATE PROCEDURE [dbo].[AddProduct]
  @ProductName VARCHAR(100)
  ,@ShortName VARCHAR(50) 
  ,@SizeGroupId VARCHAR(200)
  ,@MeasurementTypeId INT			
  ,@CreatedBy INT
  ,@ProductSizeType dbo.ProductSizeType READONLY
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Products P Where P.ProductName = @ProductName)
  BEGIN
	SET @ErrorMessage = 'Product name ' + @ProductName + ' already exists.'
	RETURN 1001;
  END

  --Insert the New value.
  INSERT INTO dbo.Products
  (
	ProductName
	,ShortName			
	,SizeGroupId		
	,MeasurementTypeId
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@ProductName
	,@ShortName			
	,@SizeGroupId		
	,@MeasurementTypeId
	,@CreatedBy
	,@CurrentDate
	,@CreatedBy
	,@CurrentDate
  )

  DECLARE @ProductId INT  = SCOPE_IDENTITY()

  EXEC dbo.MergeProductSizes @ProductId, @CreatedBy, @ProductSizeType

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END