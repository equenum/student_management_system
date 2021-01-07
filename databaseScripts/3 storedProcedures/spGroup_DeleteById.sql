USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spGroup_DeleteById]    Script Date: 1/6/2021 6:19:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGroup_DeleteById]
		@GroupId int
	
AS
BEGIN
	
	SET NOCOUNT ON;

	delete from dbo.Groups
    where GroupId = @GroupId;

END
GO


