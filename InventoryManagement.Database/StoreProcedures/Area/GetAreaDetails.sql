-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 15/03/2019
-- Description : Returns the Area details
-- ========================================================
CREATE PROCEDURE [dbo].[GetAreaDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    A.AreaId
	,A.AreaName
	,A.PinCode
	,A.CityId
	,C.CityName
	,A.RegionCode
	,A.IsActive
	,A.CreatedBy
	,A.CreatedDate
	,A.BranchTransferd
	,A.Transfered
	,A.UpdatedBy
	,A.UpdatedDate
	,A.ChangeTimeStamp
  FROM
    dbo.Area A
  LEFT JOIN dbo.City C
	ON C.CityId = A.CityId
  WHERE
    A.IsActive = COALESCE(@IsActive,A.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

