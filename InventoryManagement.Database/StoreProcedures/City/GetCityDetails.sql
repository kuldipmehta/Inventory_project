-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the City details
-- ========================================================
CREATE PROCEDURE [dbo].[GetCityDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.CityId
	,C.CityName
	,C.StateId
	,S.StateName
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.City C
  LEFT JOIN dbo.[State] S
	ON C.StateId= S.StateId
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

