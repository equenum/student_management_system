USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spStudent_GetById]    Script Date: 1/6/2021 6:19:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spStudent_GetById]
		@StudentId int
	
AS
BEGIN
	
	SET NOCOUNT ON;

    select *
	from dbo.Students
	where StudentId = @StudentId;

END
GO


