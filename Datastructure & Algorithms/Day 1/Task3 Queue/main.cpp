#include <iostream>
#include <windows.h>
#include <conio.h>

using namespace std;

/*
template <typename T>
class Node
{
private:
    T data;
    Node* next;
    Node* prev;
public:
    Node(T _data, Node* _next = NULL, Node* _prev = NULL)
    {
        data = _data;
        next = _next;
        prev = _prev;
    }

    void setNext(Node* _next) {next = _next;}
    void setPrev(Node* _prev) {prev = _prev;}
    void setData(T _data) {data = _data;}
    Node* getNext() {return next;}
    Node* getPrev() {return prev;}
    T getData() {return data;}

};
*/

class Employee {
private:
    int id, age;
    char gender, name[100], address[200];
    double salary, overtime, deduct;
    Employee *next, *prev;
public:

    Employee()
    {
        cout << "ID: ";
        cin >> id;

        cout << "Age: ";
        cin >> age;

        cout << "Gender: ";
        cin >> gender;

        cout << "Name: ";
        cin >> name;

        cout << "Address: ";
        cin >> address;

        cout << "Salary: ";
        cin >> salary;

        cout << "OverTime: ";
        cin >> overtime;

        cout << "Deduct: ";
        cin >> deduct;
    }

    void printEmp()
    {
        cout << "ID: " << id << "               Address: " << address << endl;
        cout << "Name: " << name << "             Net Salary: " << salary + overtime - deduct << endl;
        cout << "Gender: " << gender << "           Age: " << age << endl;
    }

    friend class MyQueue;
};

class MyQueue
{
private:
    Employee *head;
    Employee *tail;
    int size;
public:
    MyQueue()
    {
        head = tail = NULL;
        size = 0;
    }

    // Remove the first element from the queue
    // deallocated the original
    void Dequeue()
    {
        if (isEmpty())
        {
            cout << "Queue is empty" << endl;
            return;
        }

        Employee *temp_ptr = head;
        head = head->next;
        if (head)
            head->prev = NULL;
        else
            tail = NULL;
        cout << "Employee with ID: " << temp_ptr->id << " deleted" << endl;
        delete temp_ptr;
        --size;
    }


    // return pointer to the first element
    Employee* Peak()
    {
        return head;
    }

    // all element to the queue
    void Enqueue(Employee *source)
    {
        if (isEmpty())
        {
            head = tail = source;
        }
        else
        {
            tail->next = source;
            source->prev = tail;
            tail = source;
        }
        ++size;
    }

    bool isEmpty()
    {
        return tail == NULL;
    }

    int getSize()
    {
        return size;
    }

    void viewContent()
    {
        if (isEmpty())
            cout << "Queue is empty" << endl;
        else
        {
            Employee *temp = head;
            while (temp != NULL)
            {
                cout << "=================================================" << endl;
                temp->printEmp();
                cout << "=================================================" << endl;
                temp = temp->next;
            }
        }
    }

    ~MyQueue()
    {
        Employee *temp;
        while(head != NULL)
        {
            temp = head;
            head = head->next;
            delete temp;
        }
    }

};

int main()
{
    MyQueue q;
    Employee* temp;

    int input = 0;
    bool flag = true;
    while (flag)
    {
        system("cls");
    cout << "Task 4 - Queue" << endl;
    cout << "1- Dequeue" << endl;
    cout << "2- Peak" << endl;
    cout << "3- Enqueue" << endl;
    cout << "4- Is Empty?" << endl;
    cout << "5- ViewContent" << endl;
    cout << "6- Size" << endl;
    cout << "7- Exit" << endl;

        do
        {
            cout << "Enter your choice: ";
            cin >> input;
        }
        while (input < 1 || input > 7);


        switch(input)
        {
        case 1:
            system("cls");
            q.Dequeue();
            _getch();
            break;

        case 2:
            system("cls");
            temp = q.Peak();
            if (temp)
                q.Peak()->printEmp();
            else
                cout << "Queue is empty" << endl;

            _getch();
            break;
        case 3:
            temp = new Employee();
            q.Enqueue(temp);
            break;
        case 4:
            system("cls");
            cout << boolalpha << q.isEmpty() << endl;
            _getch();
            break;
        case 5:
            system("cls");
            q.viewContent();
            _getch();
            break;
        case 6:
            system("cls");
            cout << q.getSize() << endl;
            _getch();
            break;
        case 7:
            flag = false;
            break;
        }
    }


    return 0;
}
