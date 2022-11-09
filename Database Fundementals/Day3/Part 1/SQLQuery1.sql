-- 1.	Display the Department id, name and id and the name of its manager.
select Dnum, Dname, SSN, Fname
from Departments D, Employee E
where D.MGRSSN = E.SSN

-- 2.	Display the name of the departments and the name of the projects under its control.
select Dname, Pname
from Departments D, Project P
where P.Dnum = D.Dnum

-- 3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.
select D.*, E.Fname
from Dependent D, Employee E
where E.SSN = D.ESSN

-- 4.	Display the Id, name and location of the projects in Cairo or Alex city.
select Pnumber, Pname, Plocation
from Project
where City in ('Cairo','Alex')

-- 5.	Display the Projects full data of the projects with a name starts with "a" letter.
select *
from Project
where Pname like 'a%'

-- 6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
select E.*
from Employee E inner join Departments D
on E.Dno = D.Dnum and E.Dno = 30 and E.Salary between 1000 and 2000

-- 7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
select E.Fname, E.Lname
from Employee E, Departments D, Project P, Works_for W
where E.Dno = D.Dnum and P.Dnum = D.Dnum and W.Pno = P.Pnumber and E.Dno = 10 and W.Hours >= 10 and P.Pname = 'AL Rabwah'

-- 8.	Find the names of the employees who directly supervised with Kamel Mohamed.
select E.Fname, E.Lname
from Employee E inner join Employee S
on S.SSN = E.Superssn and S.Fname = 'Kamel' and S.Lname = 'Mohamed'

-- 9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
select E.Fname, E.Lname, P.Pname
from Employee E, Project P, Works_for W
where E.SSN = W.ESSn and P.Pnumber = W.Pno


-- 10.	For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.'
select P.Pnumber, D.Dname, E.Lname, E.Address, E.Bdate
from Project P, Departments D, Employee E
where P.Dnum = D.Dnum and D.MGRSSN = E.SSN and P.Plocation = 'Nasr City'

-- 11.	Display All Data of the managers
select distinct S.*
from Employee E inner join Employee S
on S.SSN = E.Superssn

-- 12.	Display All Employees data and the data of their dependents even if they have no dependents
select *
from Employee E left outer join Dependent D
on E.SSN = D.ESSN

-- 13.	Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
insert into Employee
values ('Mina', 'Yossry', 102672, 1997-08-24, 'Qena, Egypt', 'M', 3000, 112233, 30)

-- 14.	Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
insert into Employee
values ('Ahmed', 'Mohamed', 102660, 1995-08-24, 'Cairo, Egypt', 'M', NULL, NULL, 30)

update Employee
set Salary = Salary * 1.2
where SSN = 102672

