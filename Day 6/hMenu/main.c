#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <windows.h>

#define normalColor 0x0F
#define selectedColor 0xF0
#define Enter 0x0d
#define Esc 27
#define ExtendedKey -32
#define menuItems 3
#define itemsLength 5
#define Up 72
#define Down 80
#define Home 71
#define End 79

// Move cursor to specific location to print
void gotoxy( int column, int line );

// Change text properties (background and font)
void textattr(int color);

void clearScreen();

// print menu and highlight the current selection
void printMenu(char menu[menuItems][itemsLength], int currentChoice);

void printNewScreen();

int processInput(int *currentChoice);
int processExtendedKey(int currentChoice);


int main()
{
    char menu[menuItems][itemsLength] = {"New ", "Save", "Exit"};

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

void printNewScreen()
{
    char name[10];
    clearScreen();
    printf("Enter your name: ");
    gets(name);
    printf("Hello %s\n", name);
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
            printNewScreen();
            break;
        case 1:
            break;
        case 2:
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

