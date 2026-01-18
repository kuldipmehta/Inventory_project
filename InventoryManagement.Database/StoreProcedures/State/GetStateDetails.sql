-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the State details
-- ========================================================
CREATE PROCEDURE [dbo].[GetStateDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  SELECT
    S.StateId
	,S.StateName
	,S.StateCode
	,S.CountryId
	,C.CountryName
	,S.IsActive
	,S.CreatedBy
	,S.CreatedDate
	,S.BranchTransferd
	,S.Transfered
	,S.UpdatedBy
	,S.UpdatedDate
	,S.ChangeTimeStamp
  FROM
    dbo.State S
  LEFT JOIN dbo.Country C
	ON S.CountryId = C.CountryId
  WHERE
    S.IsActive = COALESCE(@IsActive,S.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

