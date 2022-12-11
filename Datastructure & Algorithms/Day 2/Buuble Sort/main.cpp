#include <iostream>

using namespace std;

// Sorting by bubbling the largest number to the end of the array
int bubbleSortASC(int *Arr, int size)
{
    bool sorted = false;

    for (int i = 0; i < size && !sorted; ++i)
    {
        sorted = true;
        for (int j = 0; j < size - i - 1; ++j)
        {
            if (Arr[j] > Arr[j + 1])
            {
                swap(Arr[j], Arr[j + 1]);
                sorted = false;
            }
        }
    }
}

// Sorting by bubbling the smallest number to the end of the array
int bubbleSortDESC(int *Arr, int size)
{
    bool sorted = false;

    for (int i = 0; i < size && !sorted; ++i)
    {
        sorted = true;
        for (int j = 0; j < size - i - 1; ++j)
        {
            if (Arr[j] < Arr[j + 1])
            {
                swap(Arr[j], Arr[j + 1]);
                sorted = false;
            }
        }
    }
}

void printArr(int *Arr, int size)
{
    cout << "Array:  ";
    for (int i = 0; i < size; i++)
        cout << Arr[i] << " ";

    cout << "\n===================================================" << endl;
}

int main()
{
    int Arr[11] = {45,12,5,6,9,7,8,9, -10, -5, 1000};
    printArr(Arr, 11);
    bubbleSortDESC(Arr, 11);
    printArr(Arr, 11);
    bubbleSortASC(Arr, 11);
    printArr(Arr, 11);
    return 0;
}
