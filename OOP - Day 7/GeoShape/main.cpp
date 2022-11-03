#include <iostream>

// rec triangle circle square
// standalone sum all areas with arries


// abajoura
// class shapeColor with color parameter
// inherit from it


class GeoShape
{
protected:
    double dim1, dim2;

public:
    // constructor
    GeoShape(double d1 = 0.0, double d2 = 0.0)
        :  dim1 {d1}, dim2 {d2} {}

    // setters and getters
    virtual void setDim1 (double _dim) {dim1 = _dim;}
    virtual void setDim2 (double _dim) {dim2 = _dim;}
    double getDim1() {return dim1;}
    double getDim2() {return dim2;}

    // Abstract virtual function for calculating area
    virtual double CArea() = 0;

    virtual ~GeoShape() {}

};

class Rectangle : public GeoShape
{
public:
    Rectangle(double width, double height)
        : GeoShape(width, height) {}

    double CArea() override {return dim1 * dim2;}
};

class Square : public Rectangle
{
public:
    Square(double Length)
        : Rectangle(Length, Length) {}

    void setDim1(double Length) override {dim1 = dim2 = Length;}
    void setDim2(double Length) override {dim1 = dim2 = Length;}

};

class Triangle : public GeoShape
{
public:
    Triangle(double Base, double Height)
        : GeoShape(Base, Height) {}

    double CArea() override {return 0.5 * dim1 * dim2;}
};

class Circle : public GeoShape
{
public:
    Circle(double radius)
        : GeoShape(radius, radius) {}

    void setDim1(double radius) override {dim1 = dim2 = radius;}
    void setDim2(double radius) override {dim1 = dim2 = radius;}

    double CArea() override {return 3.14 * dim1 * dim2;}
};

double SumAllShapes(Rectangle *RecArr, Square *SqArr, Circle *CArr, Triangle *TriArr, int RecSize, int SqSize, int CSize, int TriSize)
{
    double result = 0.0;

    for (int i = 0; i < RecSize; i++)
        result += RecArr[i].CArea();

    for (int i = 0; i < SqSize; i++)
        result += SqArr[i].CArea();

    for (int i = 0; i < CSize; i++)
        result += CArr[i].CArea();

    for (int i = 0; i < TriSize; i++)
        result += TriArr[i].CArea();

    return result;
}

double SumAllShapesDyn(GeoShape** Arr, int count)
{
    double result = 0.0;

    for (int i = 0; i < count; i++)
        result += Arr[i]->CArea();

    return result;
}

using namespace std;

int main()
{
    GeoShape* rec = new Rectangle(10.5,15.5);
    cout << "Rectangle Width: " << rec->getDim1() << endl;
    cout << "Rectangle Height: " << rec->getDim2() << endl;
    cout << "Rectangle Area: " << rec->CArea() << endl << endl;

    rec->setDim1(10.0);
    rec->setDim2(15.0);
    cout << "New Rectangle Width: " << rec->getDim1() << endl;
    cout << "New Rectangle Height: " << rec->getDim2() << endl;
    cout << "New Rectangle Area: " << rec->CArea() << endl << endl;

    cout << "=======================================================" << endl << endl;

    GeoShape* sq = new Square(5.1);
    cout << "Square Length: " << sq->getDim1() << endl;
    cout << "Square Area: " << sq->CArea() << endl << endl;
    sq->setDim1(7);
    cout << "New Square Length: " << sq->getDim1() << endl;
    cout << "New Square Area: " << sq->CArea() << endl << endl;

    cout << "=======================================================" << endl << endl;

    GeoShape* c = new Circle(3);
    cout << "Circle Radius: " << c->getDim1() << endl;
    cout << "Circle Area: " << c->CArea() << endl << endl;
    c->setDim1(7);
    cout << "New Circle Radius: " << c->getDim1() << endl;
    cout << "New Circle Area: " << c->CArea() << endl << endl;

    cout << "=======================================================" << endl << endl;

    GeoShape* tri = new Triangle(10.5, 15.5);
    cout << "Triangle Base: " << tri->getDim1() << endl;
    cout << "Triangle Height: " << tri->getDim2() << endl;
    cout << "Triangle Area: " << tri->CArea() << endl << endl;
    tri->setDim1(10);
    tri->setDim2(15);
    cout << "New Triangle Base: " << tri->getDim1() << endl;
    cout << "New Triangle Height: " << tri->getDim2() << endl;
    cout << "New Triangle Area: " << tri->CArea() << endl << endl;

    cout << "=======================================================" << endl << endl;

    Rectangle MultiRec[3] = {
        Rectangle(1,2), // Area = 2
        Rectangle(3,4), // Area = 12
        Rectangle(5,6) // Area = 30
    }; // Sum = 44

    Square MultiSq[3] = {
        Square(1), // 1
        Square(2), // 4
        Square(3) // 9
    }; // Sum = 14

    Circle MultiC[3] = {
        Circle(1), // 3.14
        Circle(2), // 12.56
        Circle(3) // 28.26
    }; // Sum = 43.96

    Triangle MultiTri[3] = {
        Triangle(1,2), // 1
        Triangle(3,4), // 6
        Triangle(5,6) // 15
    }; // Sum = 22

    // 44 + 14 + 43.96 + 22 = 123.96
    double SumAll = SumAllShapes(MultiRec, MultiSq, MultiC, MultiTri, 3,3,3,3);
    cout << "Sum of all shapes: " << SumAll << endl << endl;

    GeoShape* Arr[12] = {
        new Rectangle(1,2), // Area = 2
        new Rectangle(3,4), // Area = 12
        new Rectangle(5,6), // Area = 30
        new Square(1), // 1
        new Square(2), // 4
        new Square(3), //
        new Circle(1), // 3.14
        new Circle(2), // 12.56
        new Circle(3), // 28.26
        new Triangle(1,2), // 1
        new Triangle(3,4), // 6
        new Triangle(5,6) // 15
    };

    // 44 + 14 + 43.96 + 22 = 123.96
    double Sum = SumAllShapesDyn(Arr, 12);
    cout << "Sum of all shapes: " << Sum << endl << endl;

    delete rec;
    delete sq;
    delete c;
    delete tri;

    for (int i = 0; i < 12; i++)
        delete Arr[i];

    return 0;
}
