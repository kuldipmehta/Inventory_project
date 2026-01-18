-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Edit a DesignNo.
-- =============================================
CREATE PROCEDURE [dbo].[EditDesignNo]
(
  @DesignNoId INT			
  ,@CompanyId INT			
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
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.DesignNos D Where D.DesignNo = @DesignNo AND D.DesignNoId <> @DesignNoId)
  BEGIN
	SET @ErrorMessage = 'Design No ' + @DesignNo + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.DesignNos
  SET 
	CompanyId = @CompanyId
	,BranchId = @BranchId
	,DesignNo = @DesignNo
	,ItemId	= @ItemId
	,PurchaseRate = @PurchaseRate
	,SalesRate = @SalesRate
	,MRP = @MRP			
	,WhSalesRate = @WhSalesRate
	,WhSalesRate2 = @WhSalesRate2
	,MinStockQty = @MinStockQty
	,MaxStockQty= @MaxStockQty
	,Remarks = @Remarks
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    DesignNoId = @DesignNoId 
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