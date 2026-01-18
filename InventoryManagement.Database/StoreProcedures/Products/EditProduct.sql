-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Edit a Product.
-- =============================================
CREATE PROCEDURE [dbo].[EditProduct]
(
  @ProductId INT
  ,@ProductName VARCHAR(100)
  ,@ShortName VARCHAR(50) 
  ,@SizeGroupId VARCHAR(200)		
  ,@MeasurementTypeId INT		
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ProductSizeType dbo.ProductSizeType READONLY
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Products P Where P.ProductName = @ProductName AND P.ProductId <> @ProductId)
  BEGIN
	SET @ErrorMessage = 'Product name ' + @ProductName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Products
  SET 
    ProductName = @ProductName
	,ShortName = @ShortName			  
	,SizeGroupId = @SizeGroupId		  
	,MeasurementTypeId = @MeasurementTypeId
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    ProductId = @ProductId 
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

  EXEC dbo.MergeProductSizes @ProductId, @UpdatedBy, @ProductSizeType


END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END