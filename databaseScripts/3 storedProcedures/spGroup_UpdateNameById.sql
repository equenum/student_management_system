USE [UniversityDb]
GO

/****** Object:  StoredProcedure [dbo].[spGroup_UpdateNameById]    Script Date: 1/6/2021 6:19:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGroup_UpdateNameById]
		@GroupId int,
		@UpdatedName varchar(50)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	update dbo.Groups
	set Name = @UpdatedName
	where GroupId = @GroupId;

END
GO


