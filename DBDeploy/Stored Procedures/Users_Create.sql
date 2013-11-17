SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cliff Chapman
-- Create date: 2013-11-16
-- Description:	Create new user from OAuth information source
-- =============================================
CREATE PROCEDURE [dbo].Users_Create 
	-- Add the parameters for the stored procedure here
	@DisplayName NVARCHAR(150),
	@Email NVARCHAR(255),
	@ImageUrl NVARCHAR(255) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @NewEmailID TABLE (ID INT);

	-- Insert statements for procedure here
	INSERT INTO [Stac].[dbo].Emails (Email)
		OUTPUT INSERTED.ID
			INTO @NewEmailID
	VALUES (@Email);

	INSERT INTO [Stac].[dbo].Users (DisplayName, EmailID, ImageUrl)
	VALUES (@DisplayName, (SELECT TOP 1 ID FROM @NewEmailID), @ImageUrl);
END
GO
