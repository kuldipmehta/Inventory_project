-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 29/03/2019
-- Description : Returns the GlobalSettings details
-- ========================================================
CREATE PROCEDURE [dbo].[GetGlobalSettingDetails]
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    GS.GlobalSettingId
	,GS.SiteName
	,GS.CurrentSiteUrl
	,GS.Logo
	,GS.Favicon
	,GS.SiteTagLine
	,GS.SiteFooter
	,GS.ReceivedOnEmail
	,GS.SendFromEmail
	,GS.SMTP		
	,GS.[Password]
	,GS.[Port]
	,GS.[SSL]
	,GS.PathToFolder
	,GS.ListLimit
	,GS.IsActive
	,GS.CreatedBy
	,GS.CreatedDate
	,GS.UpdatedBy
	,GS.UpdatedDate
	,GS.ChangeTimeStamp
  FROM
    dbo.GlobalSettings GS

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

