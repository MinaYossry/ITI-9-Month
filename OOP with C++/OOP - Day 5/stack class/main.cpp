#include <iostream>
#include <string>

using namespace std;

template<class T>
class MyStack
{
private:
    // Array of numbers
    T *stk;

    // index to top of stack
    int tos;

    // size of stack
    int size;
public:
    // Constructor requires size of stack
    // Dynamically allocates array of length (size)
    MyStack(int _size = 5)
    {
        tos = 0;
        size = _size;
        stk = new T[size];
    }

    // Copy constructor
    MyStack(const MyStack &src)
    {
        tos = src.tos;
        size = src.size;
        stk = new T[size];
        for (int i = 0; i < size; i++)
        {
            stk[i] = src.stk[i];
        }
    }

    // Destructor
    // Free stack array
    ~MyStack()
    {
        delete [] stk;
    }

    // return true if stack is full, otherwise return false
    bool isFull() const
    {
        return tos == size;
    }

    // return true if stack is empty, otherwise return false
    bool isEmpty() const
    {
        return tos == 0;
    }

    // add number to stack until its full
    void push(T _number)
    {
        if (!isFull())
            stk[tos++] = _number;
        else
            cout << "Stack is full" << endl;
    }

    // remove number from stack until its empty
    T pop()
    {
        if (!isEmpty())
            return stk[--tos];
        else
        {
            cout << "Stack is empty" << endl;
            return -1;
        }
    }

    // print the numbers in the stack
    void print() const
    {
        cout << "\nNumbers in stack: ";
        for (int i = 0; i < tos; i++)
            cout << stk[i] << " ";
        if (tos == 0)
            cout << "Stack is empty";
        cout << endl;
    }

    MyStack reverse()
    {
        MyStack r(size);
        r.tos = this->tos;

        int start = 0, end = tos - 1;
        while (start <= end)
        {
            r.stk[start] = this->stk[end];
            r.stk[end] = this->stk[start];
            start++;
            end--;
        }


        return r;
    }

    void ViewContent()
    {
        cout << "\nStack Data: ";
        for (int i = 0; i < tos; i++)
        {
            cout << stk[i] << " ";
        }
        cout << endl << endl;
    }

    MyStack& operator=(const MyStack &rhs)
    {
        if (this != &rhs)
        {
            delete [] stk;
            tos = rhs.tos;
            size = rhs.size;
            stk = new T[size];
            for (int i = 0; i < tos; i++)
                stk[i] = rhs.stk[i];
        }

        return *this;
    }

    MyStack operator+(const MyStack &rhs)
    {
        // create copy from caller object
        MyStack result (size + rhs.size);
        for (int i = 0; i < tos; i++)
        {
            result.push(stk[i]);
        }

        for (int i = 0; i < rhs.tos; i++)
        {
            result.push(rhs.stk[i]);
        }

        return result;
    }

    T operator[](int index)
    {
        return (index >= 0 && index < tos) ? stk[index] : -1;
    }
};


int main()
{
    MyStack<int> s1(5);
    for (int i = 0; i < 4; i++)
    {
        s1.push(i + 1);
    }

    s1.ViewContent();
    cout << endl;

    MyStack<char> s4(15);
    for (int i = 0; i < 10; i++)
    {
        s4.push((char)(65+i));
    }

    s4.ViewContent();

    MyStack<string> s5 (5);
    s5.push("AAAAAA");
    s5.push("BBBBBBB");
    s5.push("CCCCCCC");

    s5.ViewContent();

    return 0;
}
