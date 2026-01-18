-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Returns the Permission details
-- ========================================================
CREATE PROCEDURE [dbo].[GetPermissionDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    P.PermissionId
	,P.PermissionName
	,P.IsActive
	,P.CreatedBy
	,P.CreatedDate
	,P.UpdatedBy
	,P.UpdatedDate
	,P.ChangeTimeStamp
  FROM
    dbo.Permission P
  WHERE
    P.IsActive = COALESCE(@IsActive, P.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

