USE [wames]
GO

INSERT INTO [dbo].[headquarters]
           (
           [headquarters_name]
           ,[city])
     VALUES
           (
           'WarsawaHQ',
           'Warsaw')
GO


GO

INSERT INTO [dbo].[games]
           (
			[title]
           ,[price]
           ,[genre_id]
           ,[team_id])
     VALUES
           (
           'Shorro', 
           2500, 
           1, 
           1)
GO


GO

INSERT INTO [dbo].[Team]
           (
           [team_name])
     VALUES
           (
           'Pixellent')
GO


GO

INSERT INTO [dbo].[genre]
           (
           [genre_name])
     VALUES
           (
           'RPG')
GO
INSERT INTO [dbo].[genre]
           (
           [genre_name])
     VALUES
           (
           'Action')
GO
INSERT INTO [dbo].[genre]
           (
           [genre_name])
     VALUES
           (
           'FPS')
GO



INSERT INTO [dbo].[departments]
           (
           [department_name]
           ,[max_employees]
           ,[headquarters_id])
     VALUES
           (
           'ART',
           20,
           1)
GO


INSERT INTO [dbo].[departments]
           (
           [department_name]
           ,[max_employees]
           ,[headquarters_id])
     VALUES
           (
           'Marketing',
           20,
           1)
GO
INSERT INTO [dbo].[departments]
           (
           [department_name]
           ,[max_employees]
           ,[headquarters_id])
     VALUES
           (
           'Design',
           20,
           1)
GO
INSERT INTO [dbo].[departments]
           (
           [department_name]
           ,[max_employees]
           ,[headquarters_id])
     VALUES
           (
           'R&D',
           20,
           1)
GO



INSERT INTO [dbo].[availablePlatforms]
           ([platformId]
           ,[platformName])
     VALUES
           ('WIN',
           'Windows')
GO


INSERT INTO wames..positions
		(position_name)
	VALUES
		('Programmer')
go


INSERT INTO wames..positions
		(position_name)
	VALUES
		('Designer')
go


INSERT INTO wames..positions
		(position_name)
	VALUES
		('Artist')
go

INSERT INTO wames..positions
		(position_name)
	VALUES
		('Menager')
go


