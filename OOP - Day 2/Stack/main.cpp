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
    // Constructor requires size of stack
    // Dynamically allocates array of length (size)
    MyStack(int _size = 5)
    {
        tos = 0;
        size = _size;
        stk = new int[size];
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
};

int main()
{
    MyStack s(5);

    // Stack is empty
    s.print();

    // 5
    s.push(5);
    s.print();
    cout << endl;

    // 5 6 7
    s.push(6);
    s.push(7);
    s.print();
    cout << endl;

    // Stack is full
    // 5 6 7 7 9
    s.push(7);
    s.push(9);
    s.push(7);
    s.print();

    cout << "\nNumber popped of the stack: " << s.pop() << endl;

    // 5 6 7 7
    s.print();
    cout << endl;

    // 5 6 8 9
    s.pop();
    s.pop();
    s.push(8);
    s.push(9);
    s.print();
    cout << endl;

    // Stack is empty
    s.pop();
    s.pop();
    s.pop();
    s.pop();
    s.print();
    return 0;
}
