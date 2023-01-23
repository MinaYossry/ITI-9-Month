// See https://aka.ms/new-console-template for more information
using Task_1;

Point3D P = new(10, 10, 10);
Console.WriteLine($"With ToSting: {P.ToString()}");
Console.WriteLine($"With operator overload: {P}");

Console.WriteLine("Enter Values for Point P1");
Point3D P1 = new();

Console.WriteLine("Enter Values for Point P2");
Point3D P2 = new();

Console.Write("\nP1 == P2:   ");
if (P1 == P2)
    Console.WriteLine("The Same");
else
    Console.WriteLine("Different");

Console.Write("\nP1.Equals(P2):  ");
if (P1.Equals(P2))
    Console.WriteLine("The Same");
else
    Console.WriteLine("Different");