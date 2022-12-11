#include <iostream>

using namespace std;

class MyStack
{
private:
    // Array of numbers
    int *stk;

    // index to top of stack
    int tos;

    // size of stack
    int size;
public:
    static int ctorCount;
    static int dctorCount;
    // Constructor requires size of stack
    // Dynamically allocates array of length (size)
    MyStack(int _size = 5)
    {
        tos = 0;
        size = _size;
        stk = new int[size];
    }

    // Copy constructor
    MyStack(const MyStack &src)
    {
        tos = src.tos;
        size = src.size;
        stk = new int[size];
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
    void push(int _number)
    {
        if (!isFull())
            stk[tos++] = _number;
        else
            cout << "Stack is full" << endl;
    }

    // remove number from stack until its empty
    int pop()
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

    friend void ViewContent(const MyStack &S);

    MyStack& operator=(const MyStack &rhs)
    {
        if (this != &rhs)
        {
            delete [] stk;
            cout << "Here3" << endl;
            tos = rhs.tos;
            size = rhs.size;
            stk = new int [size];
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

    int operator[](int index)
    {
        return (index >= 0 && index < tos) ? stk[index] : -1;
    }
};

void ViewContent(const MyStack &S)
{
    cout << "\nStack Numbers: ";
    for (int i = 0; i < S.tos; i++)
    {
        cout << S.stk[i] << " ";
    }
    cout << endl << endl;
}

int MyStack::ctorCount = 0;
int MyStack::dctorCount = 0;

int main()
{
    MyStack s1(5);
    for (int i = 0; i < 4; i++)
    {
        s1.push(i + 1);
    }

    cout << endl;

    for (int i = 0; i < 5; i++)
    {
        cout << s1[i] << " ";
    }
    cout << endl;

    MyStack s2(7);
    for (int i = 0; i < 5; i++)
    {
        s2.push(i * 10);
    }

    ViewContent(s2);

    MyStack s3;
    s3 = s1 + s2;
    ViewContent(s3);

    return 0;
}
