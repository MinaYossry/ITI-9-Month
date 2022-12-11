#include <iostream>

using namespace std;

class Complex
{
private:
    int real;
    int imaginary;
public:
    void SetReal(int _real)
    {
        real = _real;
    }
    void SetImaginary(int _imaginary)
    {
        imaginary = _imaginary;
    }

    int GetReal() const
    {
        return real;
    }

    int GetImaginary() const
    {
        return imaginary;
    }

    void print()
    {
        // Handles when real number is 0
        // only prints 0 if imaginary number is 0
        if (real != 0 || imaginary == 0)
            cout << noshowpos << real;

        // Don't print imaginary part when imaginary = 0
        // showpos to show positive sign
        if (imaginary != 0)
            cout << showpos << imaginary << "i" << endl;

    }

    // Sum to Complex number together, return new object with the result
    Complex sum(const Complex &rhs)
    {
        Complex result;

        // this refers to current object (lhs)
        result.SetReal(this->GetReal() + rhs.GetReal());
        result.SetImaginary(this->GetImaginary() + rhs.GetImaginary()) ;

        return result;
    }

};

// Subtract rhs from lhs, return new object with the result
Complex sub(const Complex &lhs,const Complex &rhs)
{
    Complex result;
    result.SetReal(lhs.GetReal() - rhs.GetReal());
    result.SetImaginary(lhs.GetImaginary() - rhs.GetImaginary()) ;
    return result;
}

int main()
{
    char exit;
    do
    {
        system("cls");
        Complex A, B, sumResult, subResult;

        // Assign data to Complex number A
        int number {};
        cout << "Enter real part of number A: ";
        cin >> number;
        A.SetReal(number);
        cout << "Enter imaginary part of number A: ";
        cin >> number;
        A.SetImaginary(number);

        // Assign data to Complex number B
        cout << "Enter real part of number B: ";
        cin >> number;
        B.SetReal(number);
        cout << "Enter imaginary part of number B: ";
        cin >> number;
        B.SetImaginary(number);

        cout << "\nComplex Number A: ";
        A.print();

        cout << "\nComplex Number B: ";
        B.print();

        // Calling member function sum and assign the result to sumResult
        sumResult = A.sum(B);

        // Calling standalone function sub and assign the result to subResult
        subResult = sub(A, B);

        cout << "\nA + B: ";
        sumResult.print();

        cout << "\nA - B: ";
        subResult.print();

        cout << endl;

        cin >> exit;
    } while(isalpha(exit));
    return 0;
}
