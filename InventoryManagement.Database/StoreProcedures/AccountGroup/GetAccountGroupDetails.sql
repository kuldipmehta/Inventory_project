-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Returns the AccountGroup details
-- ========================================================
CREATE PROCEDURE [dbo].[GetAccountGroupDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    A.GroupId
	,A.GroupIdManual
	,A.GroupName
	,A.AccountTransferToBranch
	,A.GroupTypeId
	,GT.GroupTypeName
	,A.IsActive
	,A.CreatedBy
	,A.CreatedDate
	,A.BranchTransferd
	,A.Transfered
	,A.UpdatedBy
	,A.UpdatedDate
	,A.ChangeTimeStamp
  FROM
    dbo.AccountGroups A
  INNER JOIN dbo.AccountGroupTypes GT
	ON A.GroupTypeId = GT.AccountGroupTypeId
  WHERE
    A.IsActive = COALESCE(@IsActive,A.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

