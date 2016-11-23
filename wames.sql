--firma zajmuj¹ca siê tworzeniem gier komputerowych

create database wames

create table wames.dbo.headquarters
(
	headquarters_id INT NOT NULL CONSTRAINT headquarters_PK PRIMARY KEY,
	headquarters_name VARCHAR(20),
	city VARCHAR(20)
);

create table wames.dbo.departments
(
	department_id INT NOT NULL CONSTRAINT departments_PK PRIMARY KEY,
	department_name VARCHAR(20),
	max_employees INT NOT NULL,
	headquarters_id INT NOT NULL, 
	CONSTRAINT headquarters_fk FOREIGN KEY (headquarters_id) REFERENCES wames.dbo.headquarters(headquarters_id)
);

create table wames.dbo.employees
(
	employee_id    INT NOT NULL CONSTRAINT employees_PK PRIMARY KEY,
    first_name     VARCHAR(20),
    last_name      VARCHAR(25)
	CONSTRAINT     emp_last_name_nn  NOT NULL,
    email          VARCHAR(25),
	salary         MONEY,
	department_id  INT NOT NULL,
	position_id INT NOT NULL,
	CONSTRAINT departments_fk FOREIGN KEY (department_id) REFERENCES wames.dbo.departments(department_id),
	CONSTRAINT positions_fk FOREIGN KEY (position_id) REFERENCES wames.dbo.positions(position_id)
);



create table wames.dbo.positions
(
	position_id INT NOT NULL CONSTRAINT positions_PK PRIMARY KEY,
	position_name VARCHAR(20)
);

create table wames.dbo.games
(
	id INT NOT NULL CONSTRAINT games_PK PRIMARY KEY,
	title VARCHAR(20),
	price MONEY NOT NULL,
	genre VARCHAR(20),
	employee_id INT NOT NULL,
	CONSTRAINT employee_fk FOREIGN KEY (employee_id) REFERENCES wames.dbo.employees(employee_id)
);







