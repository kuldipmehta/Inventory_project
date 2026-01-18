-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 29/03/2019
-- Description : Update a Global Setting.
-- =============================================
CREATE PROCEDURE [dbo].[UpdateGlobalSetting]
(
  @GlobalSettingId INT			
  ,@SiteName VARCHAR(120)
  ,@CurrentSiteUrl VARCHAR(500)
  ,@Logo NVARCHAR(MAX)
  ,@Favicon NVARCHAR(MAX)
  ,@SiteTagLine VARCHAR(500)
  ,@SiteFooter VARCHAR(200)
  ,@ReceivedOnEmail VARCHAR(500)
  ,@SendFromEmail VARCHAR(500)
  ,@SMTP VARCHAR(500)
  ,@Password VARCHAR(500)
  ,@Port VARCHAR(50) 
  ,@SSL BIT			
  ,@PathToFolder VARCHAR(500)
  ,@ListLimit INT			
  ,@UpdatedBy TINYINT
  ,@ChangeTimeStamp TIMESTAMP
  ,@ErrorMessage AS VARCHAR(500) = '' OUTPUT
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;
	
  DECLARE @CurrentDate AS DATETIME = GETDATE()

	-- Edit details.
  UPDATE 
    dbo.GlobalSettings
  SET 
	SiteName = @SiteName
	,CurrentSiteUrl = @CurrentSiteUrl
	,Logo = @Logo
	,Favicon = @Favicon
	,SiteTagLine = @SiteTagLine
	,SiteFooter = @SiteFooter
	,ReceivedOnEmail = @ReceivedOnEmail
	,SendFromEmail = @SendFromEmail
	,SMTP = @SMTP		
	,[Password] = @Password
	,[Port] = @Port
	,[SSL] = @SSL
	,PathToFolder = @PathToFolder
	,ListLimit = @ListLimit
    ,UpdatedBy = @UpdatedBy
    ,UpdatedDate = @CurrentDate
  WHERE 
    GlobalSettingId = @GlobalSettingId 
    AND ChangeTimeStamp = @ChangeTimeStamp

  --Check if any changes have been made.
  IF @@ROWCOUNT = 0
  BEGIN
    RETURN 1003 -- ValueChangedAfterRetrival.
  END

END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END