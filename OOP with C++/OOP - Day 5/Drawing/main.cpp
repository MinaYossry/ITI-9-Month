#include <iostream>
#include <graphics.h>
#include <windows.h>
#include <conio.h>

using namespace std;
// Change text properties (background and font)
void textattr(int color)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), color);
}




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

class Rect
{
    Point UL, LR;
    int color;
public:
    Rect(int _color = 15, int _x1 = 0, int _y1 = 0, int _x2 = 0, int _y2 = 0)
        : UL(_x1, _y1), LR(_x2, _y2), color {_color}
    {}

    void draw()
    {
        setcolor(color);
        rectangle(UL.getX(), UL.getY(), LR.getX(), LR.getY());
    }
};

class Line
{
    Point start, end;
    int color;
public:
    Line(int _color = 15, int startX = 0, int startY = 0, int endX = 0, int endY = 0)
        : color {_color}, start(startX, startY), end (endX, endY)
    {

    }

    void draw()
    {
        setcolor(color);
        line(start.getX(), start.getY(), end.getX(), end.getY());
    }
};

class Triangle
{
    Line one, two, three;
    int color;
public:
    Triangle(int _color = 15, int oneX = 0, int oneY = 0, int twoX = 0, int twoY = 0, int threeX = 0, int threeY = 0)
        : one(_color, oneX, oneY, twoX, twoY), two(_color, twoX, twoY, threeX, threeY), three(_color, threeX, threeY, oneX, oneY), color{_color}
        {

        }

    void draw()
    {
        one.draw();
        two.draw();
        three.draw();
    }
};

class Circle
{
    Point center;
    int radius;
    int color;
public:
    Circle(int _color = 15, int centerX = 0, int centerY = 0, int _radius = 0)
        : color {_color}, radius {_radius}, center(centerX, centerY)
        {

        }

    void draw()
    {
        setcolor(color);
        circle(center.getX(), center.getY(), radius);
    }
};

int main()
{
    initgraph();
    // Create rectangle
    Rect rec(5, 146, 488, 348, 557);
    rec.draw();

    // Create two vertical lines;
    Line left(10, 212, 490, 212, 379);
    Line right(10, 280, 490, 280, 379);
    left.draw();
    right.draw();

    // Create triangle
    Triangle tri(8, 168, 537, 204, 537, 186, 510);
    tri.draw();

    // Create Circle
    Circle c(6, 246, 324, 150);
    c.draw();

    // Create two inclined lines;
    Line left2(10, 212, 324, 212, 160);
    Line right2(10, 280, 324, 280, 160);
    left2.draw();
    right2.draw();


    char ch;
    cin >> ch;
    return 0;
}
