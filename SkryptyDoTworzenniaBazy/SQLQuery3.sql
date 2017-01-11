use wames;
go

IF OBJECT_ID('CalculateAverageSalaryForHeadQuarters') is not null
BEGIN
	DROP FUNCTION CalculateAverageSalaryForHeadQuarters
END
go
CREATE FUNCTION CalculateAverageSalaryForHeadQuarters 
(
    @DepartmentName Varchar(20)
	
)
RETURNS Table
AS
Return
(
	SELECT
		AVG(e.salary) [avgSalary],
		e.department_id
	FROM
		wames..employees e
	WHERE
		e.department_id = (
							SELECT
								dep.department_id
							FROM
								departments dep
							WHERE
								dep.department_name  like @DepartmentName
						  )
	Group By
		e.department_id
			 
)
go
IF OBJECT_ID('GetEmployeesFromTheDepartmentWithSalaryHigherThenAverage') is not null
BEGIN
	DROP PROCEDURE GetEmployeesFromTheDepartmentWithSalaryHigherThenAverage
END
go
CREATE PROCEDURE GetEmployeesFromTheDepartmentWithSalaryHigherThenAverage
	@DepartmentName varchar(20)
AS

	BEGIN
		SET NOCOUNT ON
		SELECT
			*
		FROM
			wames..employees e, CalculateAverageSalaryForHeadQuarters(@DepartmentName) c
			
		WHERE
			e.salary > c.avgSalary and e.department_id=c.department_id
	END 
go
exec GetEmployeesFromTheDepartmentWithSalaryHigherThenAverage 'Art'

go 
if OBJECT_ID('GetPositionByName') is not null
BEGIN
	DROP Function GetPositionByName
END
go

CREATE FUNCTION GetPositionByName
(
    @positionName varchar(20)
)
RETURNS TABLE AS RETURN
(
    SELECT
		*
	FROM
		wames..positions p
	WHERE
		p.position_name =@positionName
)

go
if OBJECT_ID('GetEmployeesByPositionName') is not null
BEGIN
	DROP PROCEDURE GetEmployeesByPositionName
END
go
CREATE PROCEDURE GetEmployeesByPositionName 
    @positionName VARCHAR(20)
AS
	SET NOCOUNT ON
    SELECT
		e.employee_id,
		e.first_name,
		e.last_name,
		e.email,
		e.salary,
		e.department_id,
		e.position_id,
		e.team_id
	FROM
		wames..employees e, GetPositionByName(@positionName) p
	WHERE
		e.position_id = p.position_id
go
exec GetEmployeesByPositionName 'Programmer'

go
IF OBJECT_ID('GetTopSalaryByPosition') is not null
BEGIN
	DROP FUNCTION GetTopSalaryByPosition
END
go
CREATE FUNCTION GetTopSalaryByPosition
(
    @PositionName VARCHAR(20)

)
RETURNS TABLE AS RETURN
(
    SELECT
		MAX(e.salary) [Max Salary],
		p.position_id
	FROM
		wames..employees e, GetPositionByName(@PositionName) p
	Where
		e.position_id = p.position_id
	GROUP BY
		p.position_id
)
go
if OBJECT_ID('GetTopEarningEmployeeByPosition') is not null
BEGIN
	DROP PROCEDURE GetTopEarningEmployeeByPosition
END
go
CREATE PROCEDURE GetTopEarningEmployeeByPosition
    @positionName VARCHAR(20)
AS
SET NOCOUNT ON
SELECT
	e.employee_id,
	e.first_name,
	e.last_name,
	e.email,
	e.salary,
	e.department_id,
	e.position_id,
	e.team_id
FROM
	wames..employees e, GetTopSalaryByPosition(@positionName) s
WHERE
	e.salary = s.[Max Salary] and s.position_id =e.position_id
go
exec GetTopEarningEmployeeByPosition 'Programmer'

go
if OBJECT_ID('GetEmployeesFromHeadQuarters') is not null
BEGIN
	DROP PROCEDURE GetEmployeesFromHeadQuarters
END
go
CREATE PROCEDURE GetEmployeesFromHeadQuarters 
    @headQuartersName VARCHAR(20)  
AS
	SET NOCOUNT ON
    SELECT
		*
	FROM
		wames..employees e
	WHERE 
	NOT EXISTs
	(
		SELECT
			*
		FROM
			wames..departments d
		WHERE
			d.department_id = e.department_id
		AND NOT EXISTS
		(
			SELECT
				*
			FROM
				wames..headquarters h
			WHERE
				h.headquarters_id = d.headquarters_id and h.headquarters_name = @headQuartersName
		)	
	) 						 
go				
exec GetEmployeesFromHeadQuarters 'MainHeadQuarters'
