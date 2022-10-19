#include <stdio.h>
#include <stdlib.h>

int main()
{
    /*
    * n = number of rows in first matrix
    * m = number of cols in first matrix = number of rows in second  matrix
    * k = number of cols in second matrix
    */

    int n = 3, m = 2, k = 1;

    int firstMatrix[n][m];

    printf("Enter data of first matrix: \n");
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < m; col++)
        {
            printf("row: %i col: %i = ", row + 1, col + 1);
            scanf("%i", &firstMatrix[row][col]);
        }
    }

    int secondMatrix[m][k];

    printf("Enter data of second matrix: \n");
    for (int row = 0; row < m; row++)
    {
        for (int col = 0; col < k; col++)
        {
            printf("row: %i col: %i = ", row + 1, col + 1);
            scanf("%i", &secondMatrix[row][col]);
        }
    }

    int result[3][1] = {0};

    for (int row = 0; row < n; row++) {
        for (int col = 0; col < m; col++) {
            result[row][0] += firstMatrix[row][col] * secondMatrix[col][0];
        }
    }

    printf("Result\n");
    printf("==============================\n");
    for (int row = 0; row < n; row++) {
        for (int col = 0; col < k; col++) {
            printf("%i ", result[row][col]);
        }
        printf("\n");
    }
    return 0;
}
