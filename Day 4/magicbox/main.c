#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>

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


// Validates that the coordinates(rows and cols) is between 1 and size
int validCoordinate(int index, int size) {
    if (index > size)
        return 0;
    else if (index <= 0)
        return size;
    else
        return index;
}

int main()
{
    // Take rectangle size for the users
    // must be odd and bigger than 3
    int size;
    do {
        printf("Enter size of Rec: ");
        scanf("%i", &size);
    } while (size % 2 == 0 || size < 3);

    int area = size * size;

    // starting position (1, middle column)
    int row = 1, col = size/2 + 1;

    for(int i = 1; i <= area; i++) {
        // offset 10 and 5 from (0,0) with 3 spacing between columns and 2 between rows
        int coordX = 10 + (col - 1) * 3;
        int coordY = 5 + (row - 1) * 2;
        gotoxy(coordX, coordY);
        printf("%i", i);

        if (i % size == 0)
            row++;
        else {
            row--;
            col--;
        }

        // Check rows and cols in boundry
        row = validCoordinate(row, size);
        col = validCoordinate(col, size);
    }


    return 0;
}
