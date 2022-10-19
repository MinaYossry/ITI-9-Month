#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char fName[20], lName[10];

    printf("Enter first name: ");
    gets(fName);
    printf("Enter last name: ");
    gets(lName);

    // Concatenate first name and last name
    strcat(fName, " ");
    strcat(fName, lName);

    printf("\nFull Name: %s", fName);
    return 0;
}
