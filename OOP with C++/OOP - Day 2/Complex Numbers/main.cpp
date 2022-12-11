#include <iostream>

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
        cout << "constructor: Address of Complex" << ": " << this << endl;
        real = _real;
        imaginary = _img;
        ctorCalls++;
        cout << "constructor Call: " << ctorCalls << endl;
    }

    ~Complex()
    {
        cout << "+destructor: Address of Complex" << ": " << this << endl;
        dctorCalls++;
        cout << "destructor Call: " << dctorCalls << endl;
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
    Complex sum(Complex rhs)
    {
        Complex result;

        // this refers to current object (lhs)
        result.SetReal(this->GetReal() + rhs.GetReal());
        result.SetImaginary(this->GetImaginary() + rhs.GetImaginary()) ;

        return result;
    }

};


int Complex::ctorCalls = 0;
int Complex::dctorCalls = 0;

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
    Complex C1(1,2), C2(5), C3;
    C3 = C1.sum(C2);
 //   C3.print();
    C3 = sub(C1, C2);
  //  C3.print();

    return 0;
}
