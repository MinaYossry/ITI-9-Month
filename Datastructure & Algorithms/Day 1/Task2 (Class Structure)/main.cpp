#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <string>
#include <windows.h>

#define normalColor 0x0F
#define selectedColor 0xF0
#define Enter 0x0d
#define Esc 27
#define ExtendedKey -32
#define menuItems 7
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

using namespace std;


char** MultilineEditor(int dataCount, int *size, int *xPos, int *yPos, char *start, char *end);

// Move cursor to specific location to print
void gotoxy( int column, int line );

void clearScreen();

class Employee {
    int id, age;
    char gender, name[100], address[200];
    double salary, overtime, deduct;
    Employee *next, *prev;

public:


    // print specific employee
    void printEmp()
    {
        printf("Employee ID: %i\n", id);
        printf("Employee Age: %i\n", age);
        printf("Employee Gender: %c\n", gender);
        printf("Employee Name: %s\n", name);
        printf("Employee Address: %s\n", address);
        printf("Employee Net Salary: %0.2f\n", (salary + overtime - deduct));
    }


    friend class LinkedList;
};

class LinkedList
{
private:
    Employee *Head, *Tail;
public:
    LinkedList()
    {
        Head = Tail = NULL;
    }

    Employee* getHead() {return Head;}
    Employee* getTail() {return Tail;}

    // add new employee info in the array
    void addNewEmp()
    {



        int dataCount = 8;
        int size[8] = {10,10,2,100,200,10,10,10};
        int xPos[8] = {20,20,20,20,55,55,55,55};
        int yPos[8] = {5,8,11,14,5,8,11,14};
        char start[8] = {48,48,97,97,97,46,46,46};
        char end[8] = {57,57,122,122,122,57,57,57};

        char **new_emp = MultilineEditor(dataCount, size, xPos, yPos, start, end);
        Employee *New_Emp = new Employee();
        New_Emp->id = atoi(new_emp[0]);
        New_Emp->age = atoi(new_emp[1]);
        New_Emp->gender = new_emp[2][0];
        strcpy(New_Emp->name, new_emp[3]);
        strcpy(New_Emp->address, new_emp[4]);
        char *ptr;
        New_Emp->salary = strtod(new_emp[5],&ptr);
        New_Emp->overtime = strtod(new_emp[6], &ptr);
        New_Emp->deduct = strtod(new_emp[7], &ptr);
        New_Emp->next = NULL;
        New_Emp->prev = NULL;

        if (Tail == NULL)
        Head = Tail = New_Emp;
        else
        {
            Tail->next = New_Emp;
            New_Emp->prev = Tail;
            Tail = New_Emp;
        }

        for (int i = 0; i < dataCount; i++)
            free(new_emp[i]);

        free(new_emp);

    }

    void deleteNode(Employee *node)
    {
        if (Head == Tail)
            Head = Tail = NULL;
        else if (Head == node)
        {
            Head = Head->next;
            Head->prev = NULL;
        }
        else if (Tail == node)
        {
            Tail = Tail->prev;
            Tail->next = NULL;
        }
        else
        {
            node->prev->next = node->next;
            node->next->prev = node->prev;
        }
        free(node);
    }

    void deleteAll()
    {
        clearScreen();
        Employee* temp = Head;
        while (Head != NULL)
        {
            Head = Head->next;
            free(temp);
        }
        printf("All Employees Deleted\n");
        _getch();
    }

    // search for the user id return index if found and -1 if not found
    Employee *employeExist(int id)
    {
        Employee *eSearch = Head;
        while(eSearch != NULL)
        {
            if(eSearch->id == id)
                return eSearch;

            eSearch = eSearch->next;
        }
        return NULL;
    }

    // Deletes employee with specific ID if exist
    void deleteByID()
    {
        clearScreen();
        int id;
        printf("Enter ID of employee: ");
        scanf("%i", &id);
        printf("\n=======================================\n");
        Employee* pSearch = employeExist(id);
        if (pSearch != NULL)
        {
            printf("Employee: %s with ID: %i Deleted\n", pSearch->name, pSearch->id);
            deleteNode(pSearch);
        }
        else
        {
            printf("There is no employee with this ID\n");
        }
        _getch();
    }

    // Deletes employee with specific name if exist
    void deleteByName()
    {
        clearScreen();
        char name[100];
        printf("Enter name of employee: ");
        _flushall();
        gets(name);
        printf("\n=======================================\n");
        Employee *pSearch = Head;
        while(pSearch != NULL)
        {
            if(strcmp(name, pSearch->name) == 0)
            {
                printf("Employee: %s with ID: %i Deleted\n", pSearch->name, pSearch->id);
                deleteNode(pSearch);
                _getch();
                return;
            }
            pSearch = pSearch->next;
        }
        printf("There is no employee with this name\n");
        _getch();
    }

    void printAll()
    {
        Employee *trav = Head;
        while(trav != NULL)
        {
            printf("\nEmployee No. %i\n", trav->id);
            printf("==========================================\n");
                trav->printEmp();
            printf("==========================================\n");
            trav = trav->next;
        }
    }
};

//struct Employee emp[employeeCount];
LinkedList EmpList;

// Change text properties (background and font)
void textattr(int color);

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

// look for employee with specific id and print his info
void searchForEmployee();

// display all employees
void displayScreen();

int main()
{

    char menu[menuItems][itemsLength] = {"New ", "Display By ID", "Display All", "Delete By ID", "Delete By Name", "Delete All", "Exit"};


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
    printNewScreen();
    EmpList.addNewEmp();

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

void searchForEmployee()
{
    clearScreen();
    int id;
    printf("Enter ID of employee: ");
    scanf("%i", &id);
    printf("\n=======================================\n");
    Employee *pSearch = EmpList.employeExist(id);
    if (pSearch != NULL)
    {
        pSearch->printEmp();
    }
    else
    {
        printf("There is no employee with this ID\n");
    }
    _getch();

}


void displayScreen()
{
    clearScreen();

    EmpList.printAll();

    _getche();
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
            EmpList.deleteByID();
            break;
        case 4:
            EmpList.deleteByName();
            break;
        case 5:
            EmpList.deleteAll();
            break;
        case 6:
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
            if (currentField == 2)
            {
                while (toupper(input) != 'M' && toupper(input) != 'F')
                {
                    input = _getch();
                }
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
            else
            {
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
            }
            break;
        }
    } while (exitFlag != 1);

    return empData;

}




