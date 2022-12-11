#include <iostream>

using namespace std;

int bSearchIt(int *Arr, int Size, int value)
{
    int start = 0;
    int end = Size - 1;

    while (start <= end)
    {
        int mid = (start + end) / 2;
        if (value > Arr[mid])
            start = mid + 1;
        else if (value < Arr[mid])
            end = mid - 1;
        else
            return mid;
    }

    return -1;
}

int bSearchR(int *Arr, int Start, int End, int value)
{
    if (Start < End)
    {
        int mid = (Start + End) / 2;

        if (Arr[mid] == value)
            return mid;
        else if (value > Arr[mid])
            return bSearchR(Arr, mid + 1, End, value);
        else if (value < Arr[mid])
            return bSearchR(Arr, Start, mid - 1, value);
    }

    return -1;
}

int main()
{
    int Arr[] = {1,2,4,6,9,17,28,33,40};

    cout << "33: Index: " << bSearchIt(Arr, 9, 33) << endl;
    cout << "65: Index: " << bSearchIt(Arr, 9, 65) << endl;
    cout << "4: Index: " << bSearchIt(Arr, 9, 4) << endl;

    cout << "\n33: Index: " << bSearchR(Arr, 0, 8, 33) << endl;
    cout << "65: Index: " << bSearchR(Arr, 0, 8, 65) << endl;
    cout << "4: Index: " << bSearchR(Arr, 0, 8, 4) << endl;

    return 0;
}
