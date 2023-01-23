using Task01;

Gender getGenderChoice()
{
    string genderChoice = string.Empty;
    Gender gender;
    Console.WriteLine("\nEnter Gender (Male/Female): ");
    do
    {
        Console.Write("Choice: ");
        genderChoice = Console.ReadLine();
    } while (!Enum.TryParse(genderChoice, true, out gender));
    
    return gender;
}

SecurityLevel getSecurityLevel()
{
    string secLevChoice = string.Empty;
    SecurityLevel sl;
    Console.WriteLine("\nEnter Security Level: ");

    do
    {
        Console.Write("Choice: ");
        secLevChoice = Console.ReadLine();
    } while (!Enum.TryParse(secLevChoice,true, out sl));

    return sl;
}

Employee[] EmpArr = new Employee[3];
EmployeeSearch ES = new(5);

for (int i = 0; i < 1; i++)
{
    int ID;
    do
    {
        Console.Write("\nEnter New ID: ");

    } while (!int.TryParse(Console.ReadLine(),out ID));


    decimal salary;

    do
    {
        Console.Write("Enter Employee Salary: ");

    } while (!decimal.TryParse(Console.ReadLine(),out salary));

        Console.Write("Enter Employee Name: ");
    string name = Console.ReadLine();

    HiringDate hireDate = new HiringDate();

    Gender gender = getGenderChoice();

    SecurityLevel securityLevel = getSecurityLevel();

    EmpArr[i] = new Employee(ID, securityLevel, salary, hireDate, gender, name);
    ES[i, ID, hireDate, name] = EmpArr[i];
}

//int searchID;
//do
//{
//    Console.Write("Search by id: ");
//} while (!int.TryParse(Console.ReadLine(), out searchID));

//Console.WriteLine(ES[searchID]);

Console.Write("Search by Name: ");
string searchName = Console.ReadLine();

Console.WriteLine(ES[searchName]);

//Console.WriteLine("Search by Hire Date: ");

////HiringDate searchHireDate = new HiringDate();
////Console.WriteLine(ES[searchHireDate]);


