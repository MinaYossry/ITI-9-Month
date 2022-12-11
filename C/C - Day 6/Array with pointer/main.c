#include <stdio.h>
#include <stdlib.h>

int main()
{
    int arr[5];
    int *ptr;
    ptr =  arr;
    for (int i = 0; i < 5; i++)
    {
        scanf("%i", &arr[i]);
    }

    printf("\n");
    for (int i = 0; i < 5; i++)
    {
        printf("%i ", *(ptr + i));
    }
    return 0;
}
