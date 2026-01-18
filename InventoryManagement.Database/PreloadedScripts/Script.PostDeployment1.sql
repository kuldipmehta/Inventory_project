/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT into GlobalSettings
(
   SiteName	
   ,CurrentSiteUrl
   ,Logo	
   ,Favicon
   ,SiteTagLine		
   ,SiteFooter		
   ,ReceivedOnEmail
   ,SendFromEmail		
   ,SMTP		
   ,[Password]			
   ,[Port]				
   ,[SSL]				
   ,PathToFolder		
   ,ListLimit			
   ,IsActive			
   ,CreatedBy			
   ,CreatedDate		
   ,UpdatedBy			
   ,UpdatedDate
)
VALUES
(
   'Inventory Management'
   ,'www.inventory.com'
   ,NULL
   ,NULL
   ,''
   ,''
   ,'hardik.surani27@gmail.com'
   ,'hardik.surani27@gmail.com'
   ,'smtp.gmail.com'
   ,'9a95bpSurani!'
   ,587			
   ,1				
   ,'Desktop'
   ,10
   ,1
   ,1
   ,GETDATE()
   ,1
   ,GETDATE()
)
