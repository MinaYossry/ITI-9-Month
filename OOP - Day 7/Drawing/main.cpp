#include <iostream>
#include <graphics.h>
#include <windows.h>
#include <conio.h>

using namespace std;


class Shape
{
protected:
    int color;
public:
    Shape(int _color) {color = _color;}

    int getColor() {return color;}
    void setColor(int _color) {color = _color;}

    virtual void draw() = 0;

    virtual ~Shape() {}
};


class Point
{
    int x, y;
public:

    // constructor with default values (0,0)
    Point(int _x = 0, int _y = 0)
        : x {_x}, y {_y}
    {}

    // Getters and Setters
    int getX() const {return x;}
    int getY() const {return y;}
    void setX(int _x) {x = _x;};
    void getX(int _y) {y = _y;}
};

class Rect : public Shape
{
    Point UL, LR;
public:
    Rect(int _color = 15, int _x1 = 0, int _y1 = 0, int _x2 = 0, int _y2 = 0)
        : UL(_x1, _y1), LR(_x2, _y2), Shape (_color)
    {}

    void draw() override
    {
        setcolor(color);
        rectangle(UL.getX(), UL.getY(), LR.getX(), LR.getY());
    }
};

class Line : public Shape
{
    Point start, end;
public:
    Line(int _color = 15, int startX = 0, int startY = 0, int endX = 0, int endY = 0)
        : Shape (_color), start(startX, startY), end (endX, endY)
    {

    }

    void draw() override
    {
        setcolor(color);
        line(start.getX(), start.getY(), end.getX(), end.getY());
    }
};

class Triangle : public Shape
{
    Line one, two, three;
public:
    Triangle(int _color = 15, int oneX = 0, int oneY = 0, int twoX = 0, int twoY = 0, int threeX = 0, int threeY = 0)
        : one(_color, oneX, oneY, twoX, twoY), two(_color, twoX, twoY, threeX, threeY), three(_color, threeX, threeY, oneX, oneY), Shape (_color)
        {

        }

    void draw() override
    {
        one.draw();
        two.draw();
        three.draw();
    }
};

class Circle : public Shape
{
    Point center;
    int radius;
public:
    Circle(int _color = 15, int centerX = 0, int centerY = 0, int _radius = 0)
        : Shape (_color), radius {_radius}, center(centerX, centerY)
        {

        }

    void draw() override
    {
        setcolor(color);
        circle(center.getX(), center.getY(), radius);
    }
};

class Picture
{
    Rect *rec;
    Line *lowerLeft, *lowerRight, *upperLeft, *upperRight;
    Triangle *tri;
    Circle *lowerCircle, *upperCircle;
public:
    Picture()
    {
        rec = NULL; lowerLeft = NULL; lowerRight = NULL;
        upperLeft = NULL; upperRight = NULL; tri = NULL;
        lowerCircle = NULL; upperCircle = NULL;
    }
    Picture (Rect *_rec, Line *_lowerLeft, Line *_lowerRight,
             Line *_upperLeft, Line *_upperRight, Triangle *_tri,
             Circle *_lower, Circle *_upper)
     {
        rec = _rec; lowerLeft = _lowerLeft; lowerRight = _lowerRight;
        upperLeft = _upperLeft; upperRight = _upperRight; tri = _tri;
        lowerCircle = _lower; upperCircle = _upper;
     }

    // setters and getters
    void setRec(Rect *_rec) {rec = _rec;}
    Rect* getRec() {return rec;}

    void setLowerLeftLine(Line *_line) {lowerLeft = _line;}
    Line* getLowerLeftLine() {return lowerLeft;}

    void setLowerRightLine(Line *_line) {lowerRight = _line;}
    Line* getLowerRightLine() {return lowerRight;}

    void setUpperLeftLine(Line *_line) {upperLeft = _line;}
    Line* getUpperLeftLine() {return upperLeft;}

    void setUpperRightLine(Line *_line) {upperRight = _line;}
    Line* getUpperRightLine() {return upperRight;}

    void setTriangle(Triangle *_tri) {tri = _tri;}
    Triangle* getTriangle() {return tri;}

    void setLowerCircle(Circle *_c) {lowerCircle = _c;}
    Circle* getLowerCircle() {return lowerCircle;}

    void setUpperCircle(Circle *_c) {upperCircle = _c;}
    Circle* getUpperircle() {return upperCircle;}

    void paint()
    {
        if (rec)
            rec->draw();

        if (lowerLeft)
            lowerLeft->draw();

        if (lowerRight)
            lowerRight-> draw();

        if (upperLeft)
            upperLeft->draw();

        if (upperRight)
            upperRight->draw();

        if (tri)
            tri->draw();

        if (lowerCircle)
            lowerCircle->draw();

        if (upperCircle)
            upperCircle->draw();
    }
};

class Picture2
{
    Shape **shapesArr;
    int shapesCount;
public:
    Picture2()
    {
        shapesArr = NULL;
        shapesCount = 0;
    }

    Picture2(Shape **_shapesArr, int _shapesCount)
    {
        shapesArr = _shapesArr;
        shapesCount = _shapesCount;
    }

    // setters and getters
    void setShapesArr(Shape **_shapesArr, int _shapesCount)
    {
        shapesArr = _shapesArr;
        shapesCount = _shapesCount;
    }
    Shape** getShapesArr() {return shapesArr;}
    int getCount() {return shapesCount;}

    void paint()
    {
        for (int i = 0; i < shapesCount; i++)
            shapesArr[i]->draw();
    }
};


int main()
{
    initgraph();

    // Create rectangle
    Rect rec(5, 146, 488, 348, 557);

    // Create two vertical lines;
    Line left(10, 212, 490, 212, 379);
    Line right(10, 280, 490, 280, 379);

    // Create triangle
    Triangle tri(8, 168, 537, 204, 537, 186, 510);

    // Create Circle
    Circle c(6, 246, 324, 150);

    // Create two inclined lines;
    Line left2(10, 170, 324, 212, 160);
    Line right2(10, 320, 324, 280, 160);

    // Create Circle
    Circle c2(6, 245, 110, 120);

    Picture pic;
    pic.setRec(&rec);
    pic.setLowerLeftLine(&left);
    pic.setLowerRightLine(&right);
    pic.setTriangle(&tri);
    pic.setLowerCircle(&c);
    pic.setUpperLeftLine(&left2);
    pic.setUpperRightLine(&right2);
    pic.setUpperCircle(&c2);
    pic.setRec(NULL);
   // pic.paint();


    Shape* shapesArr[8] = {
        &rec, &left, &right, &tri, &c, &left2, &right2, &c2
    };

    Picture2 pic2(shapesArr, 8);

    pic2.paint();


    char ch;
    cin >> ch;
    return 0;
}
