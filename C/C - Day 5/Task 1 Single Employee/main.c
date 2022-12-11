#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string.h>


struct Employee {
    int id, age;
    char gender, name[100], address[200];
    double salary, overtime, deduct;
};

struct Employee emp;

// Move cursor to specific location to print
void gotoxy( int column, int line )
{
  COORD coord;
  coord.X = column;
  coord.Y = line;
  SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
}

void clearScreen()
{
    system("cls");
}

void printNewScreen()
{
    clearScreen();
    char menu[8][20] = {
        "ID: ",
        "Age: ",
        "Gender: ",
        "Name: ",
        "Address: ",
        "Salary: ",
        "Over Time: ",
        "Deductions: "

    };

    int item = 0;
    for ( ; item < 4; item++)
    {
        gotoxy(10, 5 + 3 * item);
        printf("%s", menu[item]);
    }

    for ( ; item < 8; item++)
    {
        gotoxy(40, 5 + 3 * (item - 4));
        printf("%s", menu[item]);
    }
}

void addNewEmp()
{
    int item = 0;

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    scanf("%i", &emp.id);

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    scanf("%i", &emp.age);

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    scanf("%c", &emp.gender);

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    gets(emp.name);

    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    gets(emp.address);

    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    scanf("%lf", &emp.salary);


    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    scanf("%lf", &emp.overtime);

    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    scanf("%lf", &emp.deduct);
}

void printEmp()
{
    clearScreen();
    printf("Employee ID: %i\n", emp.id);
    printf("Employee Age: %i\n", emp.age);
    printf("Employee Gender: %c\n", emp.gender);
    printf("Employee Name: %s\n", emp.name);
    printf("Employee Address: %s\n", emp.address);
    printf("Employee Net Salary: %0.2f\n", (emp.salary + emp.overtime - emp.deduct));
}

int main()
{
    printNewScreen();
    addNewEmp();
    printEmp();

    return 0;
}
