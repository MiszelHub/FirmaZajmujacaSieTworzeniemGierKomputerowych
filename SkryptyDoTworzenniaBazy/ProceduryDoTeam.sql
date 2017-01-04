use wames
go
IF OBJECT_ID('GetTeamByGameTitle') IS NOT NULL
BEGIN
	DROP PROCEDURE GetTeamByGameTitle
END
go
CREATE PROCEDURE GetTeamByGameTitle 
    @GameTitle varchar(20)
	
AS
	SET NOCOUNT ON
    SELECT
		*
	FROM
		wames.dbo.Team T
	WHERE 
		T.[team_id] =(
						SELECT
							g.team_id
						FROM
							wames..games g
						WHERE
							g.title =   @GameTitle
					 )
go
exec GetTeamByGameTitle 'Shorro'


