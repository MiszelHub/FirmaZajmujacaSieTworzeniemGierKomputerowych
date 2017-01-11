use wames
go
if('GetEmployeesFromDepartment') is not null
BEGIN
	DROP PROCEDURE GetEmployeesFromDepartment
END
go
Create PROCEDURE [dbo].[GetEmployeesFromDepartment]
	@DepartmentName varchar(20),
	@HqName varchar(20)
AS
	SET NOCOUNT ON
BEGIN
SELECT
	*
FROM
	wames.dbo.employees e
WHERE
	e.department_id = 
					(
						SELECT
							dep.department_id
						FROM
							wames.dbo.departments dep
						WHERE
							dep.department_name = @DepartmentName
							AND
							dep.headquarters_id = (
												  	SELECT
												  		h.headquarters_id
												  	FROM
												  		wames.dbo.headquarters h
												  	WHERE
												  		h.headquarters_name = @HqName
												  )
					)
END
go
if('GetEmployeesFromTheTeam') is not null
BEGIN
	DROP PROCEDURE GetEmployeesFromTheTeam
END
go
CREATE PROCEDURE GetEmployeesFromTheTeam
	@TeamId int
AS
	SET NOCOUNT ON;
	SELECT
	e.first_name,
	e.last_name,
	e.email,
	e.salary
	FROM
		wames.dbo.employees e
	WHERE
	e.team_id = @TeamId
go
exec GetEmployeesFromTheTeam 1
go
if('GetDepartmentsFromHeadQuarters') is not null
BEGIN
	DROP PROCEDURE GetDepartmentsFromHeadQuarters
END
go
CREATE PROCEDURE GetDepartmentsFromHeadQuarters
	@HqName VARCHAR(20)
AS
	SET NOCOUNT on;
SELECT
	dep.department_name
FROM
	wames.dbo.departments dep
WHERE
	dep.headquarters_id = 
						(
							SELECT
								h.headquarters_id
							FROM
								wames.dbo.headquarters h
							WHERE
								h.headquarters_name = @HqName
						)
go
exec GetDepartmentsFromHeadQuarters 'MainHeadQuarters'