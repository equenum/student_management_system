USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spStudents_GetAll]    Script Date: 1/6/2021 6:19:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spStudents_GetAll] 
	
AS
BEGIN

	SET NOCOUNT ON;

    select *
	from dbo.Students;

END
GO


