#include <iostream>
#include <sstream>
#include <string>
#include <string.h>

using namespace std;

class Complex
{
private:
    int real;
    int imaginary;
public:
    static int ctorCalls;
    static int dctorCalls;

    Complex(int _real = 0, int _img = 0)
    {
        real = _real;
        imaginary = _img;
    }

    Complex(const Complex &rhs)
    {
        real = rhs.real;
        imaginary = rhs.imaginary;
    }

    ~Complex()
    {
    }

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

    void print() const
    {
        // Handles when real number is 0
        // only prints 0 if imaginary number is 0
        if (real != 0 || imaginary == 0)
            cout << noshowpos << real;

        // Don't print imaginary part when imaginary = 0
        // showpos to show positive sign
        if (imaginary != 0)
            cout << showpos << imaginary << "i" << endl;

        cout << endl;

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

    Complex operator+ (const Complex &rhs)
    {
        Complex result(
                       this->GetReal() + rhs.GetReal(),
                       this->GetImaginary() + rhs.GetImaginary()
                       );

        return result;
    }

    Complex operator- (const Complex &rhs)
    {
        Complex result(
                       this->GetReal() - rhs.GetReal(),
                       this->GetImaginary() - rhs.GetImaginary()
                       );

        return result;
    }

    Complex operator- (int value)
    {
        Complex result(
                       GetReal() - value,
                       GetImaginary()
                       );

        return result;
    }

    Complex& operator-=(const Complex &rhs)
    {
        real -= rhs.GetReal();
        imaginary -= rhs.GetImaginary();
        return *this;
    }

    Complex& operator-=(int value)
    {
        real -= value;
        return *this;
    }

    Complex& operator--()
    {
        --real;
        return *this;
    }

    Complex operator--(int)
    {
        Complex temp(*this);
        --real;
        return temp;
    }

    bool operator==(const Complex& rhs)
    {
        return (real == rhs.GetReal()) && (imaginary == rhs.GetImaginary());
    }

    bool operator!=(const Complex& rhs)
    {
        return (real != rhs.GetReal()) || (imaginary != rhs.GetImaginary());
    }

    bool operator>(const Complex& rhs)
    {
        if (real == rhs.GetReal())
            return imaginary > rhs.GetImaginary();
        else
            return real > rhs.GetReal();
    }

    bool operator>=(const Complex& rhs)
    {
        if (real == rhs.GetReal())
            return imaginary >= rhs.GetImaginary();
        else
            return real > rhs.GetReal();
    }

    bool operator<(const Complex& rhs)
    {
        if (real == rhs.GetReal())
            return imaginary < rhs.GetImaginary();
        else
            return real < rhs.GetReal();
    }

    bool operator<=(const Complex& rhs)
    {
        if (real == rhs.GetReal())
            return imaginary <= rhs.GetImaginary();
        else
            return real < rhs.GetReal();
    }

    operator int ()
    {
        return real;
    }

    operator char* ()
    {
        char* result = new char[10];
        string re;
        // Handles when real number is 0
        // only prints 0 if imaginary number is 0
        if (real != 0 || imaginary == 0)
        {
            re += to_string((real));
        }

        // Don't print imaginary part when imaginary = 0
        // showpos to show positive sign
        if (imaginary != 0)
        {
            if (imaginary > 0 && real != 0)
            {
                re.push_back('+');
            }
            re += to_string(imaginary);
            re.push_back('i');
        }

        strcpy(result, re.c_str());
        return result;
    }

};

Complex operator-(int value, const Complex &rhs)
{
    Complex result(
       value - rhs.GetReal(),
       rhs.GetImaginary()
       );

    return result;
}

int operator-=(int &value, const Complex &rhs)
{
    value -= rhs.GetReal();

    return value;
}

// Subtract rhs from lhs, return new object with the result
Complex sub(Complex lhs,Complex rhs)
{
    Complex result;
    result.SetReal(lhs.GetReal() - rhs.GetReal());
    result.SetImaginary(lhs.GetImaginary() - rhs.GetImaginary()) ;
    return result;
}

int main()
{
    Complex C1(1,2), C2(3,4), C3;
    cout << endl;

    C3 = C1 - C2; // -2-2i
    C3.print();
    C3 = 7 - C2; // 4+4i
    C3.print();
    C3 = C2 - 7;
    C3.print(); // -4+4i
    C1 -= C2;
    C1.print(); // -2-2i
    C1 -= 7;
    C1.print(); // -9-2i

    int x = 7;
    x -= C1;
    cout << x << endl; // 7 - (-9) == 16

    --C1;
    C1.print(); // -10-2i

    (C1--).print(); // -10-2i
    C1.print(); // -11-2i

    cout << boolalpha << (C1 == C2) << endl; // false
    Complex C4 = C1;
    cout << boolalpha << (C1 == C4) << endl << endl; // true


    cout << boolalpha << (C1 != C2) << endl; // true
    cout << boolalpha << (C1 != C4) << endl << endl; // false

    cout << boolalpha << (C1 > C2) << endl; // false
    cout << boolalpha << (C1 >= C4) << endl << endl; // true

    cout << boolalpha << (C1 < C2) << endl; // true
    cout << boolalpha << (C1 <= C4) << endl << endl; // true

    cout << (int)(C1) << endl << endl;

    char *toStr = (char *)(C2);
    printf("%s\n",toStr);
    return 0;
}
