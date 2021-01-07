USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spCourses_GetAll]    Script Date: 1/6/2021 6:19:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spCourses_GetAll]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	select *
	from dbo.Courses;
    
END
GO


