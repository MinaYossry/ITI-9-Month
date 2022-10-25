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
#define menuItems 6
#define itemsLength 20
#define Up 72
#define Down 80
#define Home 71
#define End 79
#define employeeCount 10
#define leftArrow 75
#define rightArrow 77
#define backSpace 8
#define delete 83
#define Tap 9

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

// process keyboard input from the user to enter which menu item
int processInput(int *currentChoice);

// process keyboard input in case of arrow, home and end
int processExtendedKey(int currentChoice);

// open input screen for the user and take the index of the new user
void inputScreen();

// print form for the user to inter employee info
void printNewScreen();

// add new employee info in the array
void addNewEmp(int index);

// Deletes employee with specific ID if exist
void deleteByID();

// Deletes employee with specific name if exist
void deleteByName();

// look for employee with specific id and print his info
void searchForEmployee();

// search for the user id return index if found and -1 if not found
int employeExist(int id);

// display all employees
void displayScreen();

// print specific employee
void printEmp(int index);

void lineEditor(int xPos, int yPos, char start, char end, char *line);

char** MultilineEditor(int dataCount, int *size, int *xPos, int *yPos, char *start, char *end);

int main()
{

    char menu[menuItems][itemsLength] = {"New ", "Display By ID", "Display All", "Delete By ID", "Delete By Name", "Exit"};

    for (int e = 0; e < employeeCount; e++)
    {
        emp[e].id = -1;
    }

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

    char or;
    if (emp[index].id != -1)
    {
        printf("There is an employee with this index. Override? (y,n): ");
        _flushall();
        or = _getche();
        _getch();
        if (or == 'y')
        {
            printNewScreen();
            addNewEmp(index);
            _getch();
        }
        else
        {
            printf("ok!");
        }
    }
    else
    {
        printNewScreen();
        addNewEmp(index);
    }

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

void printHighLight(int x, int y)
{
    gotoxy(x, y);
    textattr(selectedColor);
    printf("          ");
}

void removeHighLight(int x, int y, char *line)
{
    gotoxy(x, y);
    textattr(normalColor);
    printf("%-11s", line);
}

void addNewEmp(int index)
{
    int dataCount = 8;
    int size[8] = {10,10,2,100,200,10,10,10};
    int xPos[8] = {20,20,20,20,55,55,55,55};
    int yPos[8] = {5,8,11,14,5,8,11,14};
    char start[8] = {48,48,97,97,97,46,46,46};
    char end[8] = {57,57,122,122,122,57,57,57};

    char **new_emp = MultilineEditor(dataCount, size, xPos, yPos, start, end);
    emp[index].id = atoi(new_emp[0]);
    emp[index].age = atoi(new_emp[1]);
    emp[index].gender = new_emp[2][0];
    strcpy(emp[index].name, new_emp[3]);
    strcpy(emp[index].address, new_emp[4]);
    char *ptr;
    emp[index].salary = strtod(new_emp[5],&ptr);
    emp[index].overtime = strtod(new_emp[6], &ptr);
    emp[index].deduct = strtod(new_emp[7], &ptr);

    for (int i = 0; i < dataCount; i++)
        free(new_emp[i]);

    free(new_emp);
    /*
    int item = 0;
    char line[11] = {'\0'};


    printHighLight(20,5 + 3 * item);

    _flushall();
    lineEditor(20, 5 + 3 * item, 48, 57, line);
    emp[index].id = atoi(line);

    removeHighLight(20, 5 + 3 * item, line);

    item++;

    printHighLight(20,5 + 3 * item);

    _flushall();
    lineEditor(20, 5 + 3 * item, 48, 57, line);
    emp[index].age = atoi(line);

    removeHighLight(20, 5 + 3 * item, line);

    item++;

    printHighLight(20,5 + 3 * item);

    gotoxy(20, 5 + 3 * item);
    _flushall();
    char gender;
    do
    {
        gender = _getch();
    } while (toupper(gender) != 'M' && toupper(gender) != 'F');
    printf("%c", gender);
    emp[index].gender = gender;
    gotoxy(20, 5 + 3 * item);
    textattr(normalColor);
    printf("%-11c", gender);
    item++;

    printHighLight(20,5 + 3 * item);
    _flushall();
    lineEditor(20, 5 + 3 * item, 97, 122, emp[index].name);
    removeHighLight(20, 5 + 3 * item, emp[index].name);
    item++;

    printHighLight(55,5 + 3 * (item - 4));
    _flushall();
    lineEditor(55, 5 + 3 * (item - 4), 97, 122, emp[index].address);
    removeHighLight(55, 5 + 3 * (item - 4), emp[index].address);
    item++;


    char *ptr;
    printHighLight(55,5 + 3 * (item - 4));
    _flushall();
    lineEditor(55, 5 + 3 * (item - 4), 46, 57, line);
    emp[index].salary = strtod(line, &ptr);
    removeHighLight(55, 5 + 3 * (item - 4), line);
    item++;

    printHighLight(55,5 + 3 * (item - 4));
    _flushall();
    lineEditor(55, 5 + 3 * (item - 4), 46, 57, line);
    emp[index].overtime = strtod(line, &ptr);
    removeHighLight(55, 5 + 3 * (item - 4), line);
    item++;

    printHighLight(55,5 + 3 * (item - 4));
    _flushall();
    lineEditor(55, 5 + 3 * (item - 4), 46, 57, line);
    emp[index].deduct = strtod(line, &ptr);
    removeHighLight(55, 5 + 3 * (item - 4), line);
    */
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
            printf("\nEmployee No. %i\n", e);
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


void deleteByID()
{
    clearScreen();
    int id;
    printf("Enter ID of employee: ");
    scanf("%i", &id);
    printf("\n=======================================\n");
    int index = employeExist(id);
    if (index != -1)
    {
        printf("Employee: %s with ID: %i Deleted\n", emp[index].name, emp[index].id);
        emp[index].id = -1;

    }
    else
    {
        printf("There is no employee with this ID\n");
    }
    _getch();
}

void deleteByName()
{
    clearScreen();
    char name[100];
    printf("Enter name of employee: ");
    _flushall();
    gets(name);
    printf("\n=======================================\n");
    for (int e = 0; e < employeeCount; e++)
    {
        if(emp[e].id != -1 && strcmp(name, emp[e].name) == 0)
        {
            printf("Employee: %s with ID: %i Deleted\n", emp[e].name, emp[e].id);
            emp[e].id = -1;
            _getch();
            return;
        }
    }
    printf("There is no employee with this name\n");
    _getch();
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
            deleteByID();
            break;
        case 4:
            deleteByName();
            break;
        case 5:
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


void shiftArray(char *line)
{
    while(*line != '\0')
    {
        *line = *(line + 1);
        line++;
    }
}


void lineEditor(int xPos, int yPos, char start, char end, char *line)
{
    char *pCurrent = line, *pEnd = line;
    int counter = 0;
    int exitFlag = 0;

    do
    {

        gotoxy(xPos, yPos);

        char input = getch();
        switch(input)
        {
        case Enter:
            *(pEnd + 1) = '\0';
            exitFlag = 1;
            break;
        case backSpace:
            if (pCurrent > line)
            {
                shiftArray(--pCurrent);
                gotoxy(--xPos, yPos);
                printf("%s", pCurrent);
                printf(" ");
                counter--;
                pEnd--;
            }
            break;
        case Esc:
            gotoxy(0, 20);
            exit(1);
            break;
        case ExtendedKey:
            input = getch();
            switch(input)
            {
            case leftArrow:
                if (pCurrent != line)
                {
                    xPos--;
                    pCurrent--;
                }
                break;
            case rightArrow:
                if (pCurrent != pEnd + 1)
                {
                    xPos++;
                    pCurrent++;
                }
                break;
            case Home:
                xPos -= (pCurrent - line);
                pCurrent = line;
                break;
            case End:
                xPos += (pEnd - pCurrent) + 1;
                pCurrent = pEnd + 1;
                break;
            case delete:
                if (pCurrent <= pEnd)
                {
                    shiftArray(pCurrent);
                    printf("%s", pCurrent);
                    printf(" ");
                    counter--;
                    pEnd--;
                }
                break;
            default:
                break;
            }
            break;
        default:
            if (pCurrent != (line + 10) && (start <= input && input <= end) || input == ' ')
            {
                printf("%c", input);
                *pCurrent = input;
                if (pCurrent == (pEnd + 1))
                {
                    pEnd++;
                    counter++;
                }
                pCurrent++;
                xPos++;

            }
            break;
        }
    } while (exitFlag != 1);

}

char** MultilineEditor(int dataCount, int *size, int *xPos, int *yPos, char *start, char *end)
{

    // Allocate array that contains all data for one employee
    char **empData = (char**) malloc(dataCount * sizeof(char *));
    char **pCurrent = (char**) malloc(dataCount * sizeof(char *));
    char **pEnd = (char**) malloc(dataCount * sizeof(char *));

    // Allocate array for each property
    for (int data = 0; data < dataCount; data++)
    {
        empData[data] = (char *) malloc(size[data] * sizeof(char));
        pCurrent[data] = empData[data];
        pEnd[data] = empData[data];
    }

    int currentField = 0;
    int exitFlag = 0;
    int counter = 0;

    do
    {

        gotoxy(xPos[currentField], yPos[currentField]);

        _flushall();
        char input = _getch();
        switch(input)
        {
        case Enter:
            *(pEnd[currentField] + 1) = '\0';
            currentField++;
            if (currentField == dataCount)
                exitFlag = 1;
            break;
        case Tap:
            currentField = ++currentField % dataCount;
            break;
        case backSpace:
            if (pCurrent[currentField] > empData[currentField])
            {
                shiftArray(--(pCurrent[currentField]));
                gotoxy(--(xPos[currentField]), yPos[currentField]);
                printf("%s", pCurrent[currentField]);
                char ch = ' ';
                printf("%-3c", ch);
                counter--;
                (pEnd[currentField])--;
            }
            break;
        case Esc:
            gotoxy(0, 20);
            exit(1);
            break;
        case ExtendedKey:
            _flushall();
            input = _getch();
            switch(input)
            {
            case Up:
                currentField = --currentField % dataCount;
                break;
            case Down:
                currentField = ++currentField % dataCount;
                break;
            case leftArrow:
                if (pCurrent[currentField] != empData[currentField])
                {
                    (xPos[currentField])--;
                    (pCurrent[currentField])--;
                }
                break;
            case rightArrow:
                if (pCurrent[currentField] != pEnd[currentField] + 1)
                {
                    (xPos[currentField])++;
                    (pCurrent[currentField])++;
                }
                break;
            case Home:
                (xPos[currentField]) -= (pCurrent[currentField] - empData[currentField]);
                pCurrent[currentField] = empData[currentField];
                break;
            case End:
                (xPos[currentField]) += (pEnd[currentField] - pCurrent[currentField]) + 1;
                pCurrent[currentField] = pEnd[currentField] + 1;
                break;
            case delete:
                if (pCurrent[currentField] <= pEnd[currentField])
                {
                    shiftArray(pCurrent[currentField]);
                    printf("%s", pCurrent[currentField]);
                    printf(" ");
                    counter--;
                    (pEnd[currentField])--;
                }
                break;
            default:
                break;
            }
            break;
        default:
            if (pCurrent[currentField] != (empData[currentField] + size[currentField] - 1) && (start[currentField] <= input && input <= end[currentField]) || input == ' ')
            {
                printf("%c", input);
                *(pCurrent[currentField]) = input;
                if (pCurrent[currentField] == (pEnd[currentField] + 1))
                {
                    (pEnd[currentField])++;
                    counter++;
                }
                (pCurrent[currentField])++;
                (xPos[currentField])++;

            }
            break;
        }
    } while (exitFlag != 1);

    return empData;

}




