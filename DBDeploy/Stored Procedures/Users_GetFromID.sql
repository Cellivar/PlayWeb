SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cliff Chapman
-- Create date: 2013-11-16
-- Description:	Get a user's details based on UserID
-- =============================================
USE [Stac];
GO
CREATE PROCEDURE Users_GetFromID
	-- Add the parameters for the stored procedure here
	@UserID			INT = 0	OUTPUT,
	@DisplayName	NVARCHAR(150) OUTPUT,
	@Email			NVARCHAR(255) OUTPUT,
	@ImageUrl		NVARCHAR(255) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @EmailID INT;

	SELECT @DisplayName = [DisplayName], @ImageUrl = [ImageUrl], @EmailID = EmailID
	FROM [dbo].Users
	WHERE ID = @UserID;

	SELECT @Email = Email
	FROM [dbo].Emails
	WHERE ID = @EmailID;

	RETURN
END
GO
