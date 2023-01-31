using D09;

Club C1 = new() { ClubID = 1, ClubName = "C1" };
Department D1 = new() { DeptID = 1, DeptName = "D1" };
Employee E1 = new() { EmployeeID = 1, VacationStock = 21, BirthDate = new DateTime(1964,1,1) };
Employee E2 = new() { EmployeeID = 2, VacationStock = 21, BirthDate = new DateTime(1964,1,1) };
SalesPerson Sales1 = new() { EmployeeID = 3, BirthDate = new DateTime(1964, 1, 1), AchievedTarget = 10 };
BoardMember BoardMember1 = new() { EmployeeID = 4, BirthDate = new DateTime(1964, 1, 1) };

C1.AddMember(E1);
D1.AddStaff(E1);

C1.AddMember(E2);
D1.AddStaff(E2);

C1.AddMember(Sales1);
D1.AddStaff(Sales1);

C1.AddMember(BoardMember1);
D1.AddStaff(BoardMember1);

DateTime d = new DateTime(2023, 2, 1);

Console.WriteLine("Lay of because of Vacation Stock\n");
Console.WriteLine("========================================================");

E1.RequestVacation(d, new(d.Year, d.Month, d.Day + 22));

Console.WriteLine("========================================================\n");

Console.WriteLine("Lay of because of Age\n");
Console.WriteLine("========================================================");

E2.EndOfYearOperation(2025);

Console.WriteLine("========================================================\n");

Console.WriteLine("Sales Person\n");
Console.WriteLine("========================================================");

Sales1.CheckTarget(15);
Console.WriteLine("========================================================\n");

Console.WriteLine("Board Member\n");
Console.WriteLine("========================================================");

BoardMember1.Resign();
Console.WriteLine("========================================================\n");