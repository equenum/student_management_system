USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spGroups_GetAll]    Script Date: 1/6/2021 6:19:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGroups_GetAll] 

AS
BEGIN
	
	SET NOCOUNT ON;

	select *
	from dbo.Groups;
   
END
GO


