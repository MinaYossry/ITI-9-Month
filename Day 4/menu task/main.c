#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Pizza Restaurant\n");
    printf("================================\n");
    printf("1. Order Pizza\n");
    printf("2. Complaints\n");
    printf("3. Exit\n");
    printf("================================\n");
    printf("How can we help you?\n");
    int choice;
    scanf("%i", &choice);
    switch(choice)
    {
    case 1:
        printf("Thank you for your order.\n");
        break;
    case 2:
        printf("We are very sorry for this inconvenience\n");
        break;
    case 3:
        printf("Thank you\n");
        break;
    default:
        printf("Invalid input\n");
        break;
    }
    return 0;
}
