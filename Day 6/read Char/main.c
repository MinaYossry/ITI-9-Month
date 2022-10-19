#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define nameLength 10
#define Enter 0x0d

int main()
{
    char name[nameLength];

    printf("Enter your name: ");
    for (int i = 0; i < nameLength; i++)
    {
        // read character from the user
        char ch = _getche();

        // End the loop when the user press enter
        if (ch == Enter)
        {
            name[i] = '\0';
            printf("\n");
            break;
        }

        name[i] = ch;
    }

    printf("Name: %s\n", name);
    return 0;
}
