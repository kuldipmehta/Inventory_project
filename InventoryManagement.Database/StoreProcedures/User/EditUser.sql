-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Edit a User.
-- =============================================
CREATE PROCEDURE [dbo].[EditUser]
(
  @UserId INT
  ,@UserName NVARCHAR (256) 
  ,@NormalizedUserName NVARCHAR(256) 
  ,@Email NVARCHAR(256) 
  ,@NormalizedEmail NVARCHAR(256) 
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
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;
	
	IF EXISTS(SELECT 1 FROM dbo.ApplicationUser A Where A.UserName = @UserName AND A.Id <> @UserId)
	BEGIN
		SET @ErrorMessage = 'User name ' + @UserName + ' already exists.'
		RETURN 1001;
	END

	-- Edit details.
	UPDATE 
	  [dbo].ApplicationUser
	SET 
	  UserName = @UserName
	  ,NormalizedUserName = @NormalizedUserName   
	  ,Email = @Email                
	  ,NormalizedEmail = @NormalizedEmail      
	  ,EmailConfirmed = @EmailConfirmed       
	  ,PasswordHash = @PasswordHash         
	  ,PhoneNumber = @PhoneNumber          
	  ,PhoneNumberConfirmed = @PhoneNumberConfirmed 
	  ,TwoFactorEnabled = @TwoFactorEnabled     
	  ,RoleId = @RoleId 			     
	  ,[Address] = @Address			     
	  ,AdharCardNo = @AdharCardNo			 
	  ,AllowedCompanyID = @AllowedCompanyID	 
	  ,AllowedBranchID = @AllowedBranchID		 
	  ,LoginCompanyID = @LoginCompanyID		 
	  ,LoginBranchID = @LoginBranchID		 
	  ,DefaultLastFinancialYearID = @DefaultLastFinancialYearID
	  ,AllowedListingDays = @AllowedListingDays	 
	  ,AllowedDiscountLimitPrc = @AllowedDiscountLimitPrc
	  ,PreviousDateEntryDays = @PreviousDateEntryDays
	  ,PurchaseRateShow = @PurchaseRateShow	 
	  ,AllUserDataShow = @AllUserDataShow		 
	  ,AllowedDayBookID = @AllowedDayBookID	 
	  ,UserImage = @UserImage			 
	  ,UpdatedBy = @UpdatedBy
	  ,UpdatedDate = GETDATE()
	WHERE 
	  Id = @UserId 
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