--========================================================
-- Author      : HardikSurani
-- CreateDate  : 19/03/2019
-- Description : Returns the User details
--========================================================
CREATE PROCEDURE[dbo].[GetUserDetails]
@IsActive AS BIT=NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

    SELECT
	   A.Id
	   ,A.UserName
	   ,A.NormalizedUserName
	   ,A.Email
	   ,A.NormalizedEmail
	   ,A.EmailConfirmed
	   ,A.PhoneNumber
	   ,A.PhoneNumberConfirmed
	   ,A.TwoFactorEnabled
	   ,A.RoleId	
	   ,R.Name as RoleName
	   ,A.[Address]
	   ,A.AdharCardNo			
	   ,A.AllowedCompanyID	
	   ,A.AllowedBranchID		
	   ,A.LoginCompanyID		
	   ,A.LoginBranchID		
	   ,A.DefaultLastFinancialYearID
	   ,A.AllowedListingDays	
	   ,A.AllowedDiscountLimitPrc
	   ,A.PreviousDateEntryDays
	   ,A.PurchaseRateShow	
	   ,A.AllUserDataShow		
	   ,A.AllowedDayBookID	
	   ,A.UserImage			
	   ,A.IsActive
	   ,A.CreatedBy
	   ,A.CreatedDate
	   ,A.BranchTransferd
	   ,A.Transfered
	   ,A.UpdatedBy
	   ,A.UpdatedDate
	   ,A.ChangeTimeStamp
	FROM
	   dbo.ApplicationUser A
	INNER JOIN dbo.ApplicationRole R
		ON R.Id = A.RoleId		
	WHERE
	   A.IsActive = COALESCE(@IsActive, A.IsActive)

	RETURN 0
 END TRY
 	BEGIN CATCH
 	RETURN @@ERROR
 END CATCH
END
GO

