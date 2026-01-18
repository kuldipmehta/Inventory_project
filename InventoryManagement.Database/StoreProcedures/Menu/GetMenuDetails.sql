-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 19/03/2019
-- Description : Returns the Menu details
-- ========================================================
CREATE PROCEDURE [dbo].[GetMenuDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    M.MenuId
	,M.MenuName
	,M.DisplayName
	,M.Type
	,M.Url
	,M.Icon
	,M.ParentId
	,M.[Permissions]
	,M.IsActive
	,M.CreatedBy
	,M.CreatedDate
	,M.UpdatedBy
	,M.UpdatedDate
	,M.ChangeTimeStamp
  FROM
    dbo.Menu M
  WHERE
    M.IsActive = COALESCE(@IsActive, M.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

