-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Insert a new User.
-- =============================================
CREATE PROCEDURE [dbo].[AddUser]
  @UserName NVARCHAR (256) 
  ,@NormalizedUserName NVARCHAR (256) 
  ,@Email NVARCHAR (256) 
  ,@NormalizedEmail NVARCHAR (256) 
  ,@EmailConfirmed BIT            
  ,@PasswordHash NVARCHAR (MAX) 
  ,@PhoneNumber NVARCHAR (50)  
  ,@PhoneNumberConfirmed BIT            
  ,@TwoFactorEnabled BIT            
  ,@RoleId INT			
  ,@Address VARCHAR(220)   
  ,@AdharCardNo VARCHAR(30)    
  ,@AllowedCompanyID VARCHAR(120)   
  ,@AllowedBranchID	VARCHAR(120)   
  ,@LoginCompanyID INT			
  ,@LoginBranchID INT			
  ,@DefaultLastFinancialYearID BIT		
  ,@AllowedListingDays INT			
  ,@AllowedDiscountLimitPrc FLOAT		
  ,@PreviousDateEntryDays INT			
  ,@PurchaseRateShow BIT			
  ,@AllUserDataShow BIT			
  ,@AllowedDayBookID VARCHAR(MAX)	
  ,@UserImage IMAGE			
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.ApplicationUser A Where A.UserName = @UserName)
  BEGIN
	SET @ErrorMessage = 'User name ' + @UserName + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.ApplicationUser
  (
	UserName
	,NormalizedUserName   
	,Email                
	,NormalizedEmail      
	,EmailConfirmed       
	,PasswordHash         
	,PhoneNumber          
	,PhoneNumberConfirmed 
	,TwoFactorEnabled     
	,RoleId 			     
	,[Address]				 		     
	,AdharCardNo			 
	,AllowedCompanyID	 
	,AllowedBranchID		 
	,LoginCompanyID		 
	,LoginBranchID		 
	,DefaultLastFinancialYearID
	,AllowedListingDays	 
	,AllowedDiscountLimitPrc
	,PreviousDateEntryDays
	,PurchaseRateShow	 
	,AllUserDataShow		 
	,AllowedDayBookID	 
	,UserImage			 
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@UserName
	,@NormalizedUserName   
	,@Email                
	,@NormalizedEmail      
	,@EmailConfirmed       
	,@PasswordHash         
	,@PhoneNumber          
	,@PhoneNumberConfirmed 
	,@TwoFactorEnabled     
	,@RoleId 			     
	,@Address				 		     
	,@AdharCardNo			 
	,@AllowedCompanyID	 
	,@AllowedBranchID		 
	,@LoginCompanyID		 
	,@LoginBranchID		 
	,@DefaultLastFinancialYearID
	,@AllowedListingDays	 
	,@AllowedDiscountLimitPrc
	,@PreviousDateEntryDays
	,@PurchaseRateShow	 
	,@AllUserDataShow		 
	,@AllowedDayBookID	 
	,@UserImage			 
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