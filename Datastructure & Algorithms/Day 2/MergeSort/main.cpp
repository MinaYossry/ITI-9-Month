#include <iostream>

using namespace std;

void printArr(int *Arr, int size)
{
    cout << "Array:  ";
    for (int i = 0; i < size; i++)
        cout << Arr[i] << " ";

    cout << "\n===================================================" << endl;
}

void Merge(int *Arr, int LFirst, int LLast, int RFirst,int RLast)
{
    int *TempArr = new int[sizeof(Arr)/sizeof(int)];

    int index = LFirst;
    int SaveFirst = LFirst;

    while(LFirst <= LLast && RFirst <= RLast)
    {
        if (Arr[LFirst] < Arr[RFirst])
            TempArr[index++] = Arr[LFirst++];
        else
            TempArr[index++] = Arr[RFirst++];
    }

    while (LFirst <= LLast)
        TempArr[index++] = Arr[LFirst++];

    while (RFirst <= RLast)
        TempArr[index++] = Arr[RFirst++];


    for (int i = SaveFirst; i <= RLast; i++)
        Arr[i] = TempArr[i];

    delete [] TempArr;
}


void MergeSort(int *Arr, int first, int last)
{
    if (first < last)
    {
        int mid = (first + last) / 2;
        MergeSort(Arr, first, mid);
        MergeSort(Arr, mid + 1, last);
        Merge(Arr, first, mid, mid + 1, last);
    }
}



int main()
{
    int size = 11;
    int Arr[] = {45,12,5,6,9,7,8,9, -10, -5, 1000};
    printArr(Arr,  size);
    MergeSort(Arr, 0, size-1);
    printArr(Arr, size);
    return 0;
}
