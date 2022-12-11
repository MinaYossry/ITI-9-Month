#include <stdio.h>
#include <stdlib.h>

int main()
{
    const int rows = 4;
    const int cols = 5;
    int numbers[4][5] = {
        {1,2,3,4,5},
        {6,7,8,9,10},
        {11,12,13,14,15},
        {16,17,18,19,20}
    };

    double average[5] = {0.0};

    // Calculate the average of each column
    for (int col = 0; col < cols; col++) {
        // Calculate the sum
        for (int row = 0; row < rows; row++) {
            average[col] += numbers[row][col];
        }

        // Calculate average
        average[col] /= rows;
    }

    printf("Result\n");
    printf("==============================\n");
    for (int col = 0; col < cols; col++) {
        printf("Average of col %i: %.2f\n", col + 1, average[col]);
    }

    return 0;
}
