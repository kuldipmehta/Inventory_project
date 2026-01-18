-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Edit a Item.
-- =============================================
CREATE PROCEDURE [dbo].[EditItem]
(
  @ItemId INT
  ,@CompanyId INT          
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
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Items I Where I.ItemName = @ItemName AND I.ItemId <> @ItemId)
  BEGIN
	SET @ErrorMessage = 'Item name ' + @ItemName + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Items
  SET 
     CompanyId = @CompanyId	   
	,BranchId = @BranchId 	   
	,DepartmentId = @DepartmentId  
	,BrandId = @BrandId   	   
	,ProductId = @ProductId	   
	,StyleId = @StyleId       
	,GroupId = @GroupId       
	,ItemName = @ItemName	   
	,ShortName = @ShortName	   
	,BarcodeType = @BarcodeType   
	,ItemShortcut = @ItemShortcut  
	,DefaultQty = @DefaultQty    
	,HSNCode = @HSNCode	   
	,DayBookType = @DayBookType   
	,ItemWiseMargin= @ItemWiseMargin
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    ItemId = @ItemId 
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