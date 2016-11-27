--firma zajmuj¹ca siê tworzeniem gier komputerowych
IF DB_ID('wames') IS NOT NULL
BEGIN
	DROP DATABASE wames
END
go
CREATE DATABASE wames
go
use wames

CREATE TABLE wames.dbo.headquarters
(
	headquarters_id INT NOT NULL CONSTRAINT headquarters_PK PRIMARY KEY,
	headquarters_name VARCHAR(20),
	city VARCHAR(20)
);

CREATE TABLE wames.dbo.departments
(
	department_id INT NOT NULL CONSTRAINT departments_PK PRIMARY KEY,
	department_name VARCHAR(20),
	max_employees INT NOT NULL,
	headquarters_id INT NOT NULL, 
	CONSTRAINT headquarters_fk FOREIGN KEY (headquarters_id) REFERENCES wames.dbo.headquarters(headquarters_id)
);

create table wames.dbo.positions
(
	position_id INT NOT NULL CONSTRAINT positions_PK PRIMARY KEY,
	position_name VARCHAR(20)
);
CREATE TABLE dbo.Team
(
    team_id INT NOT NULL CONSTRAINT	team_PK PRIMARY KEY,
	team_name VARCHAR(50),
	
);

CREATE TABLE wames.dbo.employees
(
	employee_id    INT NOT NULL CONSTRAINT employees_PK PRIMARY KEY,
    first_name     VARCHAR(20),
    last_name      VARCHAR(25)
	CONSTRAINT     emp_last_name_nn  NOT NULL,
    email          VARCHAR(25),
	salary         MONEY,
	department_id  INT NOT NULL,
	position_id INT NOT NULL,
	team_id INT NOT NULL,
	CONSTRAINT departments_fk FOREIGN KEY (department_id) REFERENCES wames.dbo.departments(department_id),
	CONSTRAINT positions_fk FOREIGN KEY (position_id) REFERENCES wames.dbo.positions(position_id),
	CONSTRAINT team_fk FOREIGN KEY (team_id) REFERENCES wames.dbo.Team(team_id)
);

CREATE TABLE wames.dbo.genre
(
	genre_id INT NOT NULL CONSTRAINT genre_PK PRIMARY KEY,
	genre_name varchar(20)
);


CREATE TABLE wames.dbo.games
(
	id INT NOT NULL CONSTRAINT games_PK PRIMARY KEY,
	title VARCHAR(20),
	price MONEY NOT NULL,
	genre_id INT NOT NULL,
	team_id INT NOT NULL,
	CONSTRAINT teamFK FOREIGN KEY (team_id) REFERENCES wames.dbo.Team(team_id),
	CONSTRAINT genre_fk FOREIGN KEY (genre_id) REFERENCES wames.dbo.genre(genre_id)
);

CREATE TABLE wames.dbo.availablePlatforms
(
    platformId VARCHAR(3) NOT NULL CONSTRAINT platformPK PRIMARY KEY,
    platformName VARCHAR(20) NULL,
	
);

CREATE TABLE dbo.gamePlatform
(
    gameId INT NOT NULL,
	platformId Varchar(3) NOT NULL,
	CONSTRAINT gameFK FOREIGN KEY (gameId) REFERENCES wames.dbo.games(id),
	CONSTRAINT platformFK FOREIGN KEY (platformId) REFERENCES wames.dbo.availablePlatforms(platformId)
);






