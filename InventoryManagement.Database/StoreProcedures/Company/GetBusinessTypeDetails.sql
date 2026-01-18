-- ========================================================
-- Author      : Hardik Surani
-- Create Date : 03/04/2019
-- Description : Returns the Business Type details
-- ========================================================
CREATE PROCEDURE [dbo].[GetBusinessTypeDetails]
  @IsActive AS BIT = NULL
AS
BEGIN
BEGIN TRY
	SET NOCOUNT ON;

  SELECT
    B.BusinessTypeId
	,B.BusinessTypeName
	
  FROM
    dbo.BusinessTypes B
  WHERE
    B.IsActive = COALESCE(@IsActive,B.IsActive)

  RETURN 0
END TRY
BEGIN CATCH
  RETURN @@ERROR
END CATCH
END
GO

