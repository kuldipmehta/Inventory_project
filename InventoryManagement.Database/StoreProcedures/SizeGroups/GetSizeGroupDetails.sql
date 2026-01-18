-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 23/03/2019
-- Description : Returns the SizeGroup details
-- ========================================================
CREATE PROCEDURE [dbo].[GetSizeGroupDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    C.SizeGroupId
	,C.SizeGroupName
	,SGS.SizeNames
	,C.IsActive
	,C.CreatedBy
	,C.CreatedDate
	,C.BranchTransferd
	,C.Transfered
	,C.UpdatedBy
	,C.UpdatedDate
	,C.ChangeTimeStamp
  FROM
    dbo.SizeGroups C
  OUTER APPLY
  ( -- Select Role areas > Comma delimited.
    SELECT SizeNames =
      STUFF((SELECT
				',' + CONVERT(VARCHAR,SGS.SizeShortName)
			FROM 
				dbo.SizeGroupSizes SGS
	        WHERE
				SGS.SizeGroupId = C.SizeGroupId
			FOR XML PATH('')),
		1,1,'')
  ) SGS
  WHERE
    C.IsActive = COALESCE(@IsActive,C.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

