#include <stdio.h>
#include <stdlib.h>

int main()
{
    int sum = 0;
    int number = 0;
    do {
        printf("Current Sum: %i\n", sum);
        printf("Enter number to add: ");
        scanf("%i", &number);
        sum += number;
    } while (sum < 100);

    printf("\nFinal sum: %i\n", sum);
    printf("Thank You\n");

    return 0;
}
