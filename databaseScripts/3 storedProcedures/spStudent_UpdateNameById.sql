USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spStudent_UpdateNameById]    Script Date: 1/6/2021 6:19:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spStudent_UpdateNameById]
		@StudentId int,
		@UpdatedFirstName varchar(50),
		@UpdatedLastName varchar(50)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	update dbo.Students
	set FirstName = @UpdatedFirstName, LastName = @UpdatedLastName
	where StudentId = @StudentId;

END
GO


