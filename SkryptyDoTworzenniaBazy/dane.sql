USE [wames]
GO

INSERT INTO [dbo].[headquarters]
           ([headquarters_id]
           ,[headquarters_name]
           ,[city])
     VALUES
           (1,
           'WarsawaHQ',
           'Warsaw')
GO


GO

INSERT INTO [dbo].[games]
           ([id]
           ,[title]
           ,[price]
           ,[genre_id]
           ,[team_id])
     VALUES
           (1, 
           'Shorro', 
           2500, 
           1, 
           1)
GO


GO

INSERT INTO [dbo].[Team]
           ([team_id]
           ,[team_name])
     VALUES
           (1,
           'Pixellent')
GO


GO

INSERT INTO [dbo].[genre]
           ([genre_id]
           ,[genre_name])
     VALUES
           (1,
           'RPG')
GO



INSERT INTO [dbo].[departments]
           ([department_id]
           ,[department_name]
           ,[max_employees]
           ,[headquarters_id])
     VALUES
           (2,
           'Tomaszow',
           20,
           1)
GO


INSERT INTO [dbo].[departments]
           ([department_id]
           ,[department_name]
           ,[max_employees]
           ,[headquarters_id])
     VALUES
           (1,
           'Lodz',
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





