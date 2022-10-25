#include <stdio.h>
#include <stdlib.h>

void swapByValue(int x, int y)
{
    int temp = x;
    x = y;
    y = temp;
}

void swapByAdd(int *x, int *y)
{
    int temp = *x;
    *x = *y;
    *y = temp;
}

int main()
{
    int a = 4, b = 5;
    printf("Original::: a: %i, b: %i\n", a, b);
    swapByValue(a, b);
    printf("Swap by value::: a: %i, b: %i\n", a, b);
    swapByAdd(&a,&b);
    printf("Swap by address::: a: %i, b: %i\n", a, b);
    return 0;
}
