#include <iostream>

using namespace std;

class MyQueue
{
private:
    // Array of numbers
    int *qu;

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
        qu = new int[_size];
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
    void enqueue(int number)
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
    int dequeue()
    {
        if (!isEmpty())
        {
            int currentElement = qu[head];
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
        cout << "\nNumbers in Queue: ";
        for (int i = 0; i < countOfNumbers; i++)
        {
            cout << qu[temp++ % size] << " ";
        }
        if (isEmpty())
            cout << "Queue is empty";
        cout << endl;
    }
};

int main()
{

    MyQueue q(5);
    // Empty queue
    q.print();

    // 5
    q.enqueue(5);
    q.print();

    // 5 6 7
    q.enqueue(6);
    q.enqueue(7);
    q.print();
    cout << endl;

    // Queue is full
    // 5 6 7 6 7
    q.enqueue(6);
    q.enqueue(7);
    q.enqueue(6);
    q.enqueue(7);
    q.print();

    cout << "\nNumber dequeued from the queue: " << q.dequeue() << endl;

    // 6 7 6 7
    q.print();
    q.dequeue();

    // 7 6 7
    q.print();
    cout << endl;

    // 7 6 7 8 9
    q.enqueue(8);
    q.enqueue(9);
    q.print();
    cout << endl;

    // 7 8 9
    q.dequeue();
    q.dequeue();
    q.print();
    cout << endl;

    // Queue is empty
    q.dequeue();
    q.dequeue();
    q.dequeue();
    q.dequeue();
    q.print();
    return 0;
}
