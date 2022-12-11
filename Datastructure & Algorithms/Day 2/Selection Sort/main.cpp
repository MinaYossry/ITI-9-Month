#include <iostream>

using namespace std;

// return the index of the smallest number in the range [first, last[
int indexOfMin(int *Arr, int first, int last)
{
    int index = first;

    for (int i = first + 1; i < last; i++)
        if (Arr[i] < Arr[index])
            index = i;

    return index;

}

// sort the array by putting the smallest number at the beginning of the array
void SelectionSort(int *Arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        int MinIndex = indexOfMin(Arr, i, size);
        swap(Arr[i], Arr[MinIndex]);
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
    SelectionSort(Arr, 11);
    printArr(Arr, 11);

    return 0;
}
