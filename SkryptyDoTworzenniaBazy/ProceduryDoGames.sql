use wames
go
IF OBJECT_ID('GetGamesByGenre') IS NOT NULL
BEGIN
	DROP PROCEDURE GetGamesByGenre
END
go
CREATE PROCEDURE GetGamesByGenre  
    @Genre varchar(20)
AS
	SET NOCOUNT ON
    SELECT
		*
	FROM
		wames.dbo.games g
	WHERE
		g.genre_id = 
					(
						SELECT
							gen.genre_id
						FROM
							wames.dbo.genre gen
						WHERE
							gen.genre_name = @Genre
					)
go
--exec GetGamesByGenre [Action]
IF OBJECT_ID('GetGamesMadeByTeam') IS NOT NULL
BEGIN
	DROP PROCEDURE GetGamesMadeByTeam
END
go
CREATE PROCEDURE GetGamesMadeByTeam  
    @TeamName varchar(20)
AS
	SET NOCOUNT ON
    SELECT
		*
	FROM
		wames.dbo.games g
	WHERE
		g.team_id = 
					(
						SELECT
							t.team_id
						FROM
							wames.dbo.Team t
						WHERE
							t.team_name = @TeamName
					)
go
--exec GetGamesMadeByTeam TeamOne
IF OBJECT_ID('GetGamesWithPriceBelowGivenPrice') IS NOT NULL
BEGIN
	DROP PROCEDURE GetGamesWithPriceBelowGivenPrice
END
go
CREATE PROCEDURE GetGamesWithPriceBelowGivenPrice
    @Price money
	
AS
	SET NOCOUNT ON
    SELECT
		*
	FROM
		wames.dbo.games g
	Where
		g.price < @Price
	ORDER BY
		g.price
	DESC
go

exec GetGamesWithPriceBelowGivenPrice 199999
IF OBJECT_ID('GetGamesForSpecifiedPlatform') IS NOT NULL
BEGIN
	DROP PROCEDURE GetGamesForSpecifiedPlatform
END
go
CREATE PROCEDURE GetGamesForSpecifiedPlatform 
    @GamePlatform  varchar(3)
AS
	SET NOCOUNT ON
	SELECT
		g.id,
		g.title,
		g.price,
		g.genre_id,
		g.team_id
	FROM
		wames.dbo.games g JOIN gamePlatform gPl ON
		g.id = gPl.gameId
	WHERE
		gPl.platformId = @GamePlatform
go
exec GetGamesForSpecifiedPlatform Win

     