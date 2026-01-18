-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 05/04/2019
-- Description : Edit a Employee.
-- =============================================
CREATE PROCEDURE [dbo].[EditEmployee]
(
  @EmployeeId INT
  ,@CompanyId INT			
  ,@BranchId INT			
  ,@FirstName VARCHAR(120)
  ,@MiddleName VARCHAR(120)
  ,@LastName VARCHAR(120)
  ,@ShortName VARCHAR(25)
  ,@EmployeeCode VARCHAR(20)
  ,@DepartmentId INT		
  ,@DesignationId INT		
  ,@AlloweCompanyId	VARCHAR(12)
  ,@AllowedBranchId	VARCHAR(12)
  ,@Address1 VARCHAR(150)
  ,@Address2 VARCHAR(150)
  ,@Address3 VARCHAR(150)
  ,@CityId INT		
  ,@StateId INT			
  ,@PinCode VARCHAR(10)
  ,@MobileNo VARCHAR(15)
  ,@PhoneNo VARCHAR(30)
  ,@AdharCardNo VARCHAR(20)
  ,@GenderId INT			
  ,@EmailId VARCHAR(120)
  ,@BirthDate DATETIME	
  ,@JoinDate DATETIME	
  ,@ResignDate DATETIME	
  ,@WeekoffDay INT			
  ,@Salary FLOAT		
  ,@InTime TIME(7)		
  ,@OutTime TIME(7)		
  ,@AccountId INT			
  ,@CommissionOn VARCHAR(1)
  ,@CommisionPrc FLOAT		
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Employees E Where E.EmployeeCode = @EmployeeCode AND E.EmployeeId <> @EmployeeId)
  BEGIN
	SET @ErrorMessage = 'Employee code ' + @EmployeeCode + ' already exists.'
	RETURN 1001;
  END

	-- Edit details.
  UPDATE 
    dbo.Employees
  SET 
    CompanyId = @CompanyId		
	,BranchId = @BranchId		
	,FirstName = @FirstName		
	,MiddleName = @MiddleName	
	,LastName = @LastName		
	,ShortName = @ShortName		
	,EmployeeCode = @EmployeeCode	
	,DepartmentId = @DepartmentId	
	,DesignationId = @DesignationId	
	,AlloweCompanyId = @AlloweCompanyId
	,AllowedBranchId = @AllowedBranchId
	,Address1 = @Address1		
	,Address2 = @Address2		
	,Address3 = @Address3		
	,CityId	=  @CityId		
	,StateId = @StateId
	,PinCode = @PinCode		
	,MobileNo = @MobileNo		
	,PhoneNo = @PhoneNo		
	,AdharCardNo = @AdharCardNo	
	,GenderId = @GenderId		
	,EmailId = @EmailId		
	,BirthDate = @BirthDate		
	,JoinDate = @JoinDate		
	,ResignDate	= @ResignDate	
	,WeekoffDay	= @WeekoffDay	
	,Salary	= @Salary		
	,InTime	= @InTime		
	,OutTime = @OutTime		
	,AccountId = @AccountId		
	,CommissionOn = @CommissionOn	
	,CommisionPrc = @CommisionPrc	
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    EmployeeId = @EmployeeId 
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