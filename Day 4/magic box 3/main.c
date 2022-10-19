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


// Validates that the coordinates(rows and cols) is between 1 -> size
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
    int size = 3;

    int area = size*size;
    int row = 1, col = size/2 + 1;

    for(int i = 1; i <= area; i++) {

        int coordX = 10 + (col - 1) * 3;
        int coordY = 5 + (row - 1) * 2;
        gotoxy(coordX , coordY);
        printf("%i", i);
        if (i % 3 == 0)
            row++;
        else {
            row--;
            col--;
        }
        row = validCoordinate(row, size);
        col = validCoordinate(col, size);
    }

    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    printf("\n");
    return 0;
}
