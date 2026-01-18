-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 06/04/2019
-- Description : Returns the AccountGroupType details
-- ========================================================
CREATE PROCEDURE [dbo].[GetAccountGroupTypeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
	GT.AccountGroupTypeId,
	GT.GroupTypeName,
	GT.AccountGroupCrDrType,
	GT.IsActive,
	GT.CreatedBy,
	GT.CreatedDate,
	GT.UpdatedBy,
	GT.UpdatedDate,
	GT.ChangeTimeStamp
  FROM
     dbo.AccountGroupTypes GT
	WHERE
    GT.IsActive = COALESCE(@IsActive,GT.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

