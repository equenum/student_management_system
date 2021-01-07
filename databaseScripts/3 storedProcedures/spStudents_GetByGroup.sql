USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spStudents_GetByGroup]    Script Date: 1/6/2021 6:19:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spStudents_GetByGroup]
		@GroupId int
	
AS
BEGIN
	
	SET NOCOUNT ON;

    select s.*
	from dbo.Students s
	where s.GroupId = @GroupId;

END
GO


