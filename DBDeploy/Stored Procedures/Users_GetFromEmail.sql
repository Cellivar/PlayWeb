SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cliff Chapman
-- Create date: 2013-11-16
-- Description:	Get a user's details based on Email
-- =============================================
USE [Stac];
GO
CREATE PROCEDURE Users_GetFromEmail
	-- Add the parameters for the stored procedure here
	@Email			NVARCHAR(255) OUTPUT,
	@UserID			INT = 0	OUTPUT,
	@DisplayName	NVARCHAR(150) OUTPUT,
	@ImageUrl		NVARCHAR(255) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @EmailID INT;

	SELECT @EmailID = ID
	FROM [dbo].Emails
	WHERE Email = @Email;

	IF (@EmailID = NULL)
		RETURN 1
	ELSE
		SELECT @DisplayName = [DisplayName], @ImageUrl = [ImageUrl], @UserID = ID
		FROM [dbo].Users
		WHERE EmailID = @EmailID;
		RETURN
END
GO
