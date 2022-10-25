#include <stdio.h>
#include <stdlib.h>

int main()
{
    int **marks, stdN, subN, *sum, *avg;

    // Prompt the user to enter the number of students
    printf("Enter number of students: ");
    scanf("%i", &stdN);

    // Allocate array of pointers to arries
    marks = (int **) malloc(sizeof(int *) * stdN);

    // Allocate array of sum
    sum = (int) malloc(sizeof(int) * stdN);
    for (int i = 0; i < stdN; i++)
    {
        sum[i] = 0;
    }

    // Prompt the user to enter the number of subjects
    printf("Enter number of subjects: ");
    scanf("%i", &subN);

    // Allocate array of subjects marks
    for (int i = 0; i < stdN; i++)
    {
        marks[i] = (int) malloc(sizeof(int) * subN);
    }

    // Allocate array of averages
    avg = (int)  malloc(sizeof(int) * subN);
    for (int i = 0; i < subN; i++)
    {
        avg[i] = 0;
    }

    for (int student = 0; student < stdN; student++)
    {
        for (int subject = 0; subject < subN; subject++)
        {
            // prompt the user to enter subject grade
            printf("Subject: %i for Student: %i == ", subject + 1, student + 1);
            scanf("%i", &marks[student][subject]);

            // add to sum and avg arries
            sum[student] += marks[student][subject];
            avg[subject] += marks[student][subject];
        }
    }
    for (int subject = 0; subject < subN; subject++) avg[subject] /= stdN;

    for (int student = 0; student < stdN; student++)
        printf("\nSum of student: %i = %i\n", student + 1, sum[student]);

    for (int subject = 0; subject < subN; subject++)
        printf("\nAvg of subject: %i = %i\n", subject + 1, avg[subject]);

    // Free allocated memory
    for (int studnt = 0; studnt < stdN; studnt++) free(marks[studnt]);
    free(marks);
    free(sum);
    free(avg);
    return 0;
}
