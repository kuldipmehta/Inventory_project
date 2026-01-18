-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Returns the Company Type details
-- ========================================================
CREATE PROCEDURE [dbo].[GetCompanyTypeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.CompanyTypeId
	,C.CompanyTypeName
	
  FROM
    dbo.CompanyTypes C
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

