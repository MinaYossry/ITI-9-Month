#include <stdio.h>
#include <stdlib.h>

int main()
{
    int arraySize = 5;
    int numbers[arraySize];

    // Input From User
    for (int i = 0; i < arraySize; i++)
    {
        printf("Enter number %i: ", i+1);
        scanf("%i", &numbers[i]);
    }

    // Printing
    printf("\nPrinting...\n");
    for (int i = 0; i < arraySize; i++)
    {
        printf("%i ", numbers[i]);
    }
    return 0;
}
