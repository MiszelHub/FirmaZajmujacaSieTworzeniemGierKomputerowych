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
RETURNS Money
AS
Begin
declare @tmp Money
SET @tmp=(SELECT
		AVG(e.salary) [avgSalary]
	FROM
		wames..employees e
	WHERE
		e.department_id = (
							SELECT
								dep.department_id
							FROM
								departments dep
							WHERE
								dep.department_name =@DepartmentName
						  ))
			Return @tmp
END
go
IF OBJECT_ID('GetEmployeesWithSalaryHigherThenAverage') is not null
BEGIN
	DROP PROCEDURE GetEmployeesWithSalaryHigherThenAverage
END
go
CREATE PROCEDURE GetEmployeesWithSalaryHigherThenAverage
	@DepartmentName varchar(20)
AS
declare @avgSalary Money
SET @avgSalary = dbo.CalculateAverageSalaryForHeadQuarters(@DepartmentName)
	BEGIN
		SELECT
			*
		FROM
			wames..employees e
		WHERE
			e.salary > @avgSalary
	END 
go
exec GetEmployeesWithSalaryHigherThenAverage 'Lodz'


