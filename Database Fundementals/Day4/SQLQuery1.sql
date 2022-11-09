-- 1.	Display (Using Union Function)
-- a.	 The name and the gender of the dependence that's gender is Female and depending on Female Employee.
-- b.	 And the male dependence that depends on Male Employee.
select D.Dependent_name, D.Sex
from Employee E, Dependent D
where E.SSN = D.ESSN and D.Sex = 'F' and E.Sex = 'F'
union
select D.Dependent_name, D.Sex
from Employee E, Dependent D
where E.SSN = D.ESSN and D.Sex = 'M' and E.Sex = 'M'

-- 2.	For each project, list the project name and the total hours per week (for all employees) spent on that project.
select P.Pname, sum(W.Hours)
from Project P, Works_for W
where P.Pnumber = W.Pno
group by P.Pname

-- 3.	Display the data of the department which has the smallest employee ID over all employees' ID.
select D.*
from Departments D, Employee E
where D.Dnum = E.Dno
and E.SSN = (select min(SSN) from Employee)

-- 4.	For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
select D.Dname, max(E.Salary) as MAX, min(E.Salary) as MIN, AVG(E.Salary) as AVG
from Departments D, Employee E
where D.Dnum = E.Dno
group by D.Dname

-- 5.	List the full name of all managers who have no dependents.
select E.Fname+' '+E.Lname as [Full Name]
from Employee E
except
select E.Fname+' '+E.Lname as [Full Name]
from Employee E, Dependent D
where E.SSN = D.ESSN

-- 6.	For each department-- if its average salary is less than the average salary of all employees-- display its number, name and number of its employees.
select D.Dnum, D.Dname, count(E.SSN)
from Departments D, Employee E
where D.Dnum = E.Dno
group by D.Dnum, D.Dname
having avg(E.Salary) < (select avg(Salary) from Employee)

-- 7.	Retrieve a list of employees names and the projects names they are working on ordered by department number and within each department, ordered alphabetically by last name, first name.
select E.Fname+' '+E.Lname as [Full Name], P.Pname, E.Dno
from Employee E, Project P, Works_for W
where W.ESSn = E.SSN and P.Pnumber = W.Pno
order by E.Dno, E.Lname, E.Fname

-- 8.	Try to get the max 2 salaries using subquery
select (select max(Salary) from Employee) as MAX,
	   (select max(Salary) from Employee
		where salary not in (select max(Salary)
		from Employee)) as Second

-- 9.	Get the full name of employees that is similar to any dependent name
select E.Fname+' '+E.Lname as Name
from Employee E
intersect
select D.Dependent_name as Name
from Dependent D

-- 10.	Display the employee number and name if at least one of them have dependents (use exists keyword) self-study.
select E.SSN, E.Fname
from Employee E, Dependent D
where E.SSN = D.ESSN

select E.SSN, E.Fname
from Employee E
where exists
(select ESSN from Dependent D where E.SSN = D.ESSN)


-- 11.	In the department table insert new department called "DEPT IT" , with id 100, employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'
insert into Departments
values('DEPT IT', 100, 112233, '2006-11-1')

-- 12
update Departments
set MGRSSN = 968574
where Dnum = 100

update Departments
set MGRSSN = 102672
where Dnum = 20

update Employee
set Superssn = 102672
where SSN = 102660

delete from Dependent
where ESSN = 223344

update Employee
set Superssn = 102672
where Superssn = 223344

update Departments
set MGRSSN = 102672
where MGRSSN = 223344

update Works_for
set ESSn = 102672
where ESSn = 223344

delete from Employee
where SSN = 223344

-- 14.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
update Employee
set Salary = Salary * 1.3
from Employee E, Project P, Works_for W
where E.SSN = W.ESSn and P.Pnumber = W.Pno and P.Pname = 'Al Rabwah'

