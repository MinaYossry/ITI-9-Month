#include <iostream>
#include <string>

using namespace std;

template <class T>
class MyQueue
{
private:
    // Array of numbers
    T *qu;

    // tail of queue
    int tail;

    // index of first element to dequeue
    int head;

    // count of numbers in queue
    int countOfNumbers;

    // size of queue
    int size;

public:

    // Constructor requires size of queue
    // Dynamically allocates array of length (size)
    // Assign all counters to zero
    MyQueue(int _size = 5)
    {
        tail = 0;
        head = 0;
        countOfNumbers = 0;
        size = _size;
        qu = new T[_size];
    }

    // Destructor
    // Free queue array
    ~MyQueue()
    {
        delete [] qu;
    }

    // return true if stack is full, otherwise return false
    bool isFull() const
    {
        return countOfNumbers == size;
    }

    // return true if stack is empty, otherwise return false
    bool isEmpty() const
    {
        return countOfNumbers == 0;
    }

    // add numbers to queue
    void enqueue(T number)
    {
        if (!isFull())
        {
            qu[tail] = number;
            tail = ++tail % size;
            countOfNumbers++;
        }
        else
            cout << "Queue is full" << endl;
    }

    // remove numbers from queue
    T dequeue()
    {
        if (!isEmpty())
        {
            T currentElement = qu[head];
            head = ++head % size;
            countOfNumbers--;
            return currentElement;
        }
        else
            cout << "Queue is empty" << endl;
            return -1;
    }

    // print numbers in queue
    void print() const
    {
        int temp = head;
        cout << "\Data in Queue: ";
        for (int i = 0; i < countOfNumbers; i++)
        {
            cout << qu[temp++ % size] << " ";
        }
        if (isEmpty())
            cout << "Queue is empty";
        cout << endl << endl;
    }
};

int main()
{

    MyQueue<int> q1(5);
    for (int i = 0; i < 5; i++)
    {
        q1.enqueue(i+1);
    }
    q1.print();

    MyQueue<char> q2(5);
    for (int i = 0; i < 5; i++)
    {
        q2.enqueue((char)(i+65));
    }
    q2.print();

    MyQueue<string> q3(5);
    for (int i = 0; i < 5; i++)
    {
        q3.enqueue(string(5,(char)(65+i)));
    }
    q3.print();

    return 0;
}
