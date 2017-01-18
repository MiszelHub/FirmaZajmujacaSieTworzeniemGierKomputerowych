use wames

go

CREATE TRIGGER CreateDefaultDepartments
    ON wames.dbo.headquarters
    FOR INSERT
    AS
    BEGIN
    SET NOCOUNT ON

	INSERT INTO wames..departments (headquarters_id,department_name,max_employees) 
	SELECT 
		i.headquarters_id,
		'Art',
		5
	FROM
		inserted i

	INSERT INTO wames..departments (headquarters_id,department_name,max_employees) 
	SELECT 
		i.headquarters_id,
		'Design',
		5
	FROM
		inserted i

	INSERT INTO wames..departments (headquarters_id,department_name,max_employees) 
	SELECT 
		i.headquarters_id,
		'R&D',
		10
	FROM
		inserted i

    END
