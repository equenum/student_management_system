USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spGroups_GetByCourse]    Script Date: 1/6/2021 6:19:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGroups_GetByCourse]
		@CourseId int
	
AS
BEGIN
	
	SET NOCOUNT ON;

    select g.*
	from dbo.Groups g
	where g.CourseId = @CourseId;

END
GO


