#include <iostream>

using namespace std;

class intArray
{
private:
    int *Arr;
    int size;
public:

    // Allocates new array with size and initialize all values to zero
    void allocateArray(int _size, int *src_arr = nullptr)
    {
        size = _size;
        Arr = new int[size];

        // If there is source array to copy data from
        if (src_arr)
        {
            for (int i = 0; i < size; i++)
                Arr[i] = src_arr[i];
        }

        // For initializing new intArr
        else
        {
            for (int i = 0; i < size; i++)
                Arr[i] = 0;
        }
    }

    // constructor with default size to 10
    intArray(int _size = 10)
    {
        allocateArray(_size);
    }

    // destructor that frees the memory
    ~intArray()
    {
        delete [] Arr;
    }

    // copy constructor
    intArray(const intArray &src)
    {
        allocateArray(src.size, src.Arr);
    }

    // assignment operator overloard
    intArray& operator=(const intArray &src)
    {
        if (this != &src)
        {
            delete [] Arr;
            allocateArray(src.size, src.Arr);
        }

        return *this;
    }

    // square brackets for access and setting values in specific index
    int& operator[](int index)
    {
        if (inRange(index))
            return Arr[index];
    }

    intArray operator+(const intArray &rhs)
    {
        int max_range = min(size, rhs.size);

        // creates a copy of the larger array and add the smaller one to it
        if (size >= rhs.size)
        {
            intArray result(*this);
            for (int i = 0; i < max_range; i++)
                result.Arr[i] += rhs.Arr[i];
            return result;
        }
        else
        {
            intArray result(rhs);
            for (int i = 0; i < max_range; i++)
                result[i] += Arr[i];
            return result;
        }
    }

    void setArrValues(int index, int value)
    {
        if (inRange(index))
            Arr[index] = value;
    }

    // checks if specific index is in range of [0,size[
    bool inRange(int index)
    {
        return (index >= 0) && (index < size);
    }

    int getSize()
    {
        return size;
    }

    void printArray()
    {
        cout << "\nArray: ";
        for (int i = 0; i < size; i++)
        {
            cout << Arr[i] << " ";
        }
        cout << endl << endl;
    }
};

int main()
{
    intArray Arr1(7);

    for (int i = 0; i < Arr1.getSize(); i++)
    {
        Arr1[i] = 3*i;
        cout << Arr1[i] << " ";
    }

    // 0 3 6 9 12 15 18
    Arr1.printArray();

    Arr1.setArrValues(5, 999);

    // 0 3 6 9 12 999 18
    Arr1.printArray();

    intArray Arr2(10);
        for (int i = 0; i < Arr2.getSize(); i++)
    {
        Arr2[i] = 4*i;
        cout << Arr2[i] << " ";
    }

    // 0 4 8 12 16 20 24 28 32 26
    Arr2.printArray();

    intArray Arr3;
    Arr3 = Arr1 + Arr2;

    // 0 4 8 12 16 20 24 28 32 26
    Arr3.printArray();
    return 0;
}
