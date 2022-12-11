#include <iostream>

using namespace std;

void InsertionSort(int *Arr, int size)
{
    /*
    * sorted range
    * assuming first element is sorted
    */
    int sortedEnd = 0;

    for (int i = 1; i < size; i++)
    {
        /*
        * if it's smaller then find the correct position between [sortedStart, sortedEnd]
        *
        * if the element is larger than the last element in the range then its sorted
        * increase the sorted range
        */
        if (Arr[i] < Arr[sortedEnd])
        {
            int tempPosition = i;
            for (int j = sortedEnd; j >= 0; j--)
            {
                if (Arr[tempPosition] < Arr[j])
                    swap(Arr[tempPosition--], Arr[j]);
                else
                    break;
            }
        }

        sortedEnd = i;
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
    InsertionSort(Arr, 11);
    printArr(Arr, 11);

    return 0;
}
