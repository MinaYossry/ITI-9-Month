#include <iostream>
#include <string>

using namespace std;

template<class T>
class Array
{
private:
    T *Arr;
    int size;
public:

    // Allocates new array with size and initialize all values to zero
    void allocateArray(int _size, T *src_arr = NULL)
    {
        size = _size;
        Arr = new T[size];

        // If there is source array to copy data from
        if (src_arr)
        {
            for (int i = 0; i < size; i++)
                Arr[i] = src_arr[i];
        }

        // For initializing new intArr

    }

    // constructor with default size to 10
    Array(int _size = 10)
    {
        allocateArray(_size);
    }

    // destructor that frees the memory
    ~Array()
    {
        delete [] Arr;
    }

    // copy constructor
    Array(const Array &src)
    {
        allocateArray(src.size, src.Arr);
    }

    // assignment operator overloard
    Array& operator=(const Array &src)
    {
        if (this != &src)
        {
            delete [] Arr;
            allocateArray(src.size, src.Arr);
        }

        return *this;
    }

    // square brackets for access and setting values in specific index
    T& operator[](int index)
    {
        if (inRange(index))
            return Arr[index];
    }

    Array operator+(const Array &rhs)
    {
        int max_range = min(size, rhs.size);

        // creates a copy of the larger array and add the smaller one to it
        if (size >= rhs.size)
        {
            Array result(*this);
            for (int i = 0; i < max_range; i++)
                result.Arr[i] += rhs.Arr[i];
            return result;
        }
        else
        {
            Array result(rhs);
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
    Array<int> Arr1(7);

    for (int i = 0; i < Arr1.getSize(); i++)
    {
        Arr1[i] = 3*i;
    }

    // 0 3 6 9 12 15 18
    Arr1.printArray();


    Array<char> Arr4(10);
    for (int i = 0; i < 10; i++)
    {
        Arr4[i] = char(65 + i);
    }
    Arr4.printArray();

    Array<string> Arr5(10);
    for (int i = 0; i < 10; i++)
    {
        Arr5[i] = string(5, char(65 + i));
    }
    Arr5.printArray();
    return 0;
}
