-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 05/04/2019
-- Description : Returns the Employee details
-- ========================================================
CREATE PROCEDURE [dbo].[GetEmployeeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    E.EmployeeId
	,E.CompanyId 	
	,E.BranchId 	
	,E.FirstName 	
	,E.MiddleName 
	,E.LastName 	
	,E.ShortName 	
	,E.EmployeeCode 
	,E.DepartmentId 
	,DEP.DepartmentName 
	,E.DesignationId 
	,D.Designation
	,E.AlloweCompanyId
	,E.AllowedBranchId
	,E.Address1 	
	,E.Address2 	
	,E.Address3 	
	,E.CityId 	
	,C.CityName
	,C.StateId
	,S.StateName
	,E.PinCode 	
	,E.MobileNo 	
	,E.PhoneNo 	
	,E.AdharCardNo 
	,E.GenderId 	
	,E.EmailId 	
	,E.BirthDate 	
	,E.JoinDate 	
	,E.ResignDate 
	,E.WeekoffDay 
	,E.Salary 	
	,E.InTime 	
	,E.OutTime 	
	,E.AccountId 	
	,E.CommissionOn 
	,E.CommisionPrc 
	,E.IsActive
	,E.CreatedBy
	,E.CreatedDate
	,E.BranchTransferd
	,E.UpdatedBy
	,E.UpdatedDate
	,E.ChangeTimeStamp
  FROM
    dbo.Employees E
  INNER JOIN dbo.EmployeeDepartments DEP
	ON DEP.EmployeeDepartmentId = E.DepartmentId
  LEFT JOIN dbo.EmployeeDesignations D
	ON D.DesignationId = E.DesignationId
  LEFT JOIN dbo.City C
	ON C.CityId = E.CityId
  LEFT JOIN dbo.State S
	ON S.StateId = E.StateId
  WHERE
    E.IsActive = COALESCE(@IsActive,E.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

