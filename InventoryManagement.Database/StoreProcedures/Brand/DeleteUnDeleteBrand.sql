-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 22/03/2019
-- Description : Deletes/UnDelete a Brands.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUnDeleteBrands]
(
  @BrandId	AS SMALLINT
  ,@IsActive AS BIT
  ,@UpdatedBy AS TINYINT
  ,@ChangeTimeStamp AS TIMESTAMP
)
AS
BEGIN
BEGIN TRY
  SET NOCOUNT ON;

  -- Set Brands Deleted state.
  UPDATE
    dbo.Brands
  SET
    IsActive = @IsActive,
    UpdatedBy = @UpdatedBy,
    UpdatedDate = GETDATE()
  WHERE
    BrandId = @BrandId
    AND IsActive <> @IsActive
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