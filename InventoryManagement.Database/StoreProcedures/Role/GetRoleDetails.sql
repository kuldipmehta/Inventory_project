-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Role details
-- ========================================================
CREATE PROCEDURE [dbo].[GetRoleDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  SELECT
    A.Id
	,A.Name
	,A.IsActive
	,A.CreatedBy
	,A.CreatedDate
	,A.UpdatedBy
	,A.UpdatedDate
	,A.ChangeTimeStamp
  FROM
    dbo.ApplicationRole A
  WHERE
    A.IsActive = COALESCE(@IsActive,A.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

