#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <windows.h>

#define normalColor 0x0F
#define selectedColor 0xF0
#define Enter 0x0d
#define Esc 27
#define ExtendedKey -32
#define menuItems 4
#define itemsLength 20
#define Up 72
#define Down 80
#define Home 71
#define End 79
#define employeeCount 10

struct Employee {
    int id, age;
    char gender, name[100], address[200];
    double salary, overtime, deduct;
};

struct Employee emp[employeeCount];


// Move cursor to specific location to print
void gotoxy( int column, int line );

// Change text properties (background and font)
void textattr(int color);

void clearScreen();

// print menu and highlight the current selection
void printMenu(char menu[menuItems][itemsLength], int currentChoice);

int processInput(int *currentChoice);
int processExtendedKey(int currentChoice);

void inputScreen();
void printNewScreen();
void addNewEmp(int index);


void searchForEmployee();
int employeExist(int id);
void displayScreen();
void printEmp(int index);




int main()
{
    char menu[menuItems][itemsLength] = {"New ", "Display By ID", "Display All", "Exit"};

    for (int e = 0; e < employeeCount; e++)
    {
        emp[e].id = -1;
    }

    struct Employee Emps[3];

    int currentChoice = 0;
    int exitFlag = 0;

    do
    {
        clearScreen();

        printMenu(menu, currentChoice);

        exitFlag = processInput(&currentChoice);

    } while (!exitFlag);


    return 0;
}

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

// Change text properties (background and font)
void textattr(int color)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), color);
}


void clearScreen()
{
    textattr(normalColor);
    system("cls");
}

// print menu and highlight the current selection
void printMenu(char menu[menuItems][itemsLength], int currentChoice)
{
    for (int i = 0; i < menuItems; i++)
    {
        // highlight current selection
        if (currentChoice == i)
            textattr(selectedColor);
        else
            textattr(normalColor);

        // offset (10, 5) from (0,0) with spacing 3 between each item
        gotoxy(10, 5 + i * 3);
        printf("%s", menu[i]);
    }
}

void inputScreen()
{
    clearScreen();
    int index;
    printf("Enter index of employee: ");
    scanf("%i", &index);

    printNewScreen();
    addNewEmp(index - 1);
}

void printNewScreen()
{
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

void addNewEmp(int index)
{
    int item = 0;

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    scanf("%i", &emp[index].id);

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    scanf("%i", &emp[index].age);

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    scanf("%c", &emp[index].gender);

    gotoxy(20, 5 + 3 * item++);
    _flushall();
    gets(emp[index].name);

    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    gets(emp[index].address);

    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    scanf("%lf", &emp[index].salary);


    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    scanf("%lf", &emp[index].overtime);

    gotoxy(55, 5 + 3 * (item++ - 4));
    _flushall();
    scanf("%lf", &emp[index].deduct);
}

void searchForEmployee()
{
    clearScreen();
    int id;
    printf("Enter ID of employee: ");
    scanf("%i", &id);
    printf("\n=======================================\n");
    int index = employeExist(id);
    if (index != -1)
    {
        printEmp(index);
    }
    else
    {
        printf("There is no employee with this ID\n");
    }
    _getch();

}

int employeExist(int id)
{
    for (int e = 0; e < employeeCount; e++)
    {
        if(emp[e].id == id)
            return e;
    }
    return -1;
}

void displayScreen()
{
    clearScreen();
    for (int e = 0; e < employeeCount; e++)
    {
        if (emp[e].id != -1)
        {
            printf("\nEmployee No. %i\n", e+1);
            printf("==========================================\n");
                printEmp(e);
            printf("==========================================\n");
        }
    }
    _getche();
}

void printEmp(int index)
{
    printf("Employee ID: %i\n", emp[index].id);
    printf("Employee Age: %i\n", emp[index].age);
    printf("Employee Gender: %c\n", emp[index].gender);
    printf("Employee Name: %s\n", emp[index].name);
    printf("Employee Address: %s\n", emp[index].address);
    printf("Employee Net Salary: %0.2f\n", (emp[index].salary + emp[index].overtime - emp[index].deduct));
}


int processInput(int *currentChoice)
{

    int exitFlag = 0;

    char input = _getch();
    switch(input)
    {
    case Enter:
        switch(*currentChoice)
        {
        case 0:
            inputScreen();
            break;
        case 1:
            searchForEmployee();
            break;
        case 2:
            displayScreen();
            break;
        case 3:
            exitFlag = 1;
            break;
        }
        break;
    case Esc:
        exitFlag = 1;
        break;
    case ExtendedKey:
        *currentChoice = processExtendedKey(*currentChoice);
        break;
    }

    return exitFlag;
}


int processExtendedKey(int currentChoice)
{
    char input = _getch();
    switch(input)
    {
        // up arrow key
    case Up:
        currentChoice--;
        if (currentChoice == -1)
            currentChoice = menuItems - 1;
        break;
        // down arrow key
    case Down:
        currentChoice++;
        if (currentChoice == menuItems)
            currentChoice = 0;
        break;
        // home key
    case Home:
        currentChoice = 0;
        break;
        // end key
    case End:
        currentChoice = menuItems - 1;
        break;
    }
    return currentChoice;
}

