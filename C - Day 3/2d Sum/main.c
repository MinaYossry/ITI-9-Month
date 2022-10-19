#include <stdio.h>
#include <stdlib.h>

int main()
{
    int rows = 4, cols = 5;
    int numbers[4][5] = {
        {1,2,3,4,5},
        {6,7,8,9,10},
        {11,12,13,14,15},
        {16,17,18,19,20}
    };

    int sum[4] = {0};

    // Calculate the sum of each row
    for (int row = 0; row < rows; row++) {
        for (int col = 0; col < cols; col++) {
            sum[row] += numbers[row][col];
        }
    }

    printf("Result\n");
    printf("==============================\n");
    for (int row = 0; row < rows; row++) {
        printf("Sum of row %i: %i\n", row + 1, sum[row]);
    }

    return 0;
}
