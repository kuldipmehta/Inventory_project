-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 28/03/2019
-- Description : Returns the County Wise Size Details By Id
-- ========================================================
CREATE PROCEDURE [dbo].[GetSizeCountyDetailsById]
  @SizeId INT 
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    D.DepartmentId
	,D.DepartmentName
	,CASE WHEN ISNULL(S.SizeId,'') = '' THEN '' ELSE ISNULL(SC.USSizeShortName,'') END AS USSizeShortName
	,CASE WHEN ISNULL(S.SizeId,'') = '' THEN '' ELSE ISNULL(SC.EuropSizeShortName,'') END AS EuropSizeShortName
	,CASE WHEN ISNULL(S.SizeId,'') = '' THEN 0 ELSE ISNULL(SC.LengthCM,0) END AS LengthCM
	,CASE WHEN ISNULL(S.SizeId,'') = '' THEN 0 ELSE ISNULL(SC.LengthInch,0) END AS LengthInch
	,CASE WHEN ISNULL(S.SizeId,'') = '' THEN NULL ELSE SC.ChangeTimeStamp END AS ChangeTimeStamp
  FROM
    dbo.Departments D
  OUTER APPLY(
	SELECT 
		ISNULL(SC.USSizeShortName,'') AS USSizeShortName
		,ISNULL(SC.EuropSizeShortName,'') AS EuropSizeShortName
		,ISNULL(SC.LengthCM,0) AS LengthCM
		,ISNULL(SC.LengthInch,0) AS LengthInch
		,SC.ChangeTimeStamp
		,SC.SizeShortName
	FROM	
		dbo.SizeCountries SC
	INNER JOIN dbo.Sizes S
		ON S.ShortName = SC.SizeShortName
	WHERE
		D.DepartmentId = SC.SizeDepartmentId
		AND S.SizeId = @SizeId
	) SC
  OUTER APPLY(
	SELECT 
		S.SizeId
	FROM	
		dbo.Sizes S
	WHERE
		S.ShortName = SC.SizeShortName
		AND S.SizeId = @SizeId
	) S
  WHERE
	D.IsActive = 1
	AND (ISNULL(S.SizeId,'') = '' 
		 OR S.SizeId = @SizeId)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

