-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Insert a new Design No.
-- =============================================
CREATE PROCEDURE [dbo].[AddDesignNo]
  @CompanyId INT			
  ,@BranchId INT			
  ,@DesignNo VARCHAR(100)
  ,@ItemId INT			
  ,@PurchaseRate FLOAT		
  ,@SalesRate FLOAT		
  ,@MRP FLOAT		
  ,@WhSalesRate	FLOAT		
  ,@WhSalesRate2 FLOAT		
  ,@MinStockQty FLOAT		
  ,@MaxStockQty FLOAT		
  ,@Remarks VARCHAR(200)
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.DesignNos A Where A.DesignNo = @DesignNo)
  BEGIN
	SET @ErrorMessage = 'Design No ' + @DesignNo + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.DesignNos
  (
	
	CompanyId
	,BranchId	
	,DesignNo	
	,ItemId
	,PurchaseRate
	,SalesRate		
	,MRP		
	,WhSalesRate
	,WhSalesRate2
	,MinStockQty
	,MaxStockQty
	,Remarks		
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
    
	@CompanyId
	,@BranchId	
	,@DesignNo	
	,@ItemId
	,@PurchaseRate
	,@SalesRate		
	,@MRP		
	,@WhSalesRate
	,@WhSalesRate2
	,@MinStockQty
	,@MaxStockQty
	,@Remarks		
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