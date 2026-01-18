-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Insert a new Item.
-- =============================================
CREATE PROCEDURE [dbo].[AddItem]
  @CompanyId INT          
  ,@BranchId INT          
  ,@DepartmentId INT          
  ,@BrandId INT          
  ,@ProductId INT          
  ,@StyleId INT          
  ,@GroupId INT          
  ,@ItemName VARCHAR(120) 
  ,@ShortName VARCHAR(40)  
  ,@BarcodeType CHAR(1)	   
  ,@ItemShortcut VARCHAR(3)   
  ,@DefaultQty FLOAT		   
  ,@HSNCode VARCHAR(25)  
  ,@DayBookType CHAR(1)      
  ,@ItemWiseMargin BIT		   
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Items I Where I.ItemName = @ItemName)
  BEGIN
	SET @ErrorMessage = 'Item name ' + @ItemName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Items
  (
	CompanyId
	,BranchId 
	,DepartmentId
	,BrandId   
	,ProductId
	,StyleId      
	,GroupId      
	,ItemName
	,ShortName
	,BarcodeType
	,ItemShortcut
	,DefaultQty   
	,HSNCode
	,DayBookType
	,ItemWiseMargin
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CompanyId
	,@BranchId 
	,@DepartmentId
	,@BrandId   
	,@ProductId
	,@StyleId      
	,@GroupId      
	,@ItemName
	,@ShortName
	,@BarcodeType
	,@ItemShortcut
	,@DefaultQty   
	,@HSNCode
	,@DayBookType
	,@ItemWiseMargin
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