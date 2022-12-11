#include <stdio.h>
#include <stdlib.h>

int main()
{

    int numbers[] = {5,98,0,4,-56,68,1,-23,263};
    int min = numbers[0], max = numbers[0];

    // calculate the length of array
    int arraySize = sizeof(numbers) / sizeof(int);

    for (int i = 0; i < arraySize; i++)
    {
        // Find the minimum number
        if (numbers[i] < min)
            min = numbers[i];

        // Find the maximum number
        if (numbers[i] > max)
            max = numbers[i];
    }

    printf("Result\n");
    printf("==============================\n");
    printf("Min: %i\n", min);
    printf("Max: %i\n", max);
    return 0;
}
