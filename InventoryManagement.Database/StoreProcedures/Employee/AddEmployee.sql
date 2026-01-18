-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 05/04/2019
-- Description : Insert a new Employee.
-- =============================================
CREATE PROCEDURE [dbo].[AddEmployee]
  @CompanyId INT			
  ,@BranchId INT			
  ,@FirstName VARCHAR(120)
  ,@MiddleName VARCHAR(120)
  ,@LastName VARCHAR(120)
  ,@ShortName VARCHAR(25)
  ,@EmployeeCode VARCHAR(20)
  ,@DepartmentId INT			
  ,@DesignationId INT			
  ,@AlloweCompanyId	VARCHAR(120)
  ,@AllowedBranchId	VARCHAR(120)
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
  ,@CreatedBy INT
  ,@ErrorMessage AS VARCHAR(100) = '' OUTPUT
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  DECLARE @CurrentDate AS DATETIME = GETDATE()

  IF EXISTS(SELECT 1 FROM dbo.Employees E Where E.EmployeeCode = @EmployeeCode)
  BEGIN
	SET @ErrorMessage = 'Employee code ' + @EmployeeCode  + ' already exists.'
	RETURN 1001;
  END

  -- Insert the New value.
  INSERT INTO dbo.Employees
  (
	CompanyId		
	,BranchId		
	,FirstName		
	,MiddleName	
	,LastName		
	,ShortName		
	,EmployeeCode	
	,DepartmentId	
	,DesignationId	
	,AlloweCompanyId
	,AllowedBranchId
	,Address1		
	,Address2		
	,Address3		
	,CityId		
	,StateId
	,PinCode		
	,MobileNo		
	,PhoneNo		
	,AdharCardNo	
	,GenderId		
	,EmailId		
	,BirthDate		
	,JoinDate		
	,ResignDate	
	,WeekoffDay	
	,Salary		
	,InTime		
	,OutTime		
	,AccountId		
	,CommissionOn	
	,CommisionPrc	
	,CreatedBy
	,CreatedDate
	,UpdatedBy
	,UpdatedDate
  )
  VALUES
  (
	@CompanyId		
	,@BranchId		
	,@FirstName		
	,@MiddleName	
	,@LastName		
	,@ShortName		
	,@EmployeeCode	
	,@DepartmentId	
	,@DesignationId	
	,@AlloweCompanyId
	,@AllowedBranchId
	,@Address1		
	,@Address2		
	,@Address3		
	,@CityId		
	,@StateId
	,@PinCode		
	,@MobileNo		
	,@PhoneNo		
	,@AdharCardNo	
	,@GenderId		
	,@EmailId		
	,@BirthDate		
	,@JoinDate		
	,@ResignDate	
	,@WeekoffDay	
	,@Salary		
	,@InTime		
	,@OutTime		
	,@AccountId		
	,@CommissionOn	
	,@CommisionPrc	
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