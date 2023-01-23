using DurationName;

Duration D1 = new(1, 10, 15);
Console.WriteLine($"D1 = {D1.ToString()}");
Console.WriteLine();

Duration D2 = new(3600);
Console.WriteLine($"D2 = {D2.ToString()}");
Console.WriteLine();

Duration D3 = new(7800);
Console.WriteLine($"D3 = {D3.ToString()}");
Console.WriteLine();

Duration D4 = new(666);
Console.WriteLine($"D4 = {D4.ToString()}");
Console.WriteLine();

D3 = D1 + D2;
Console.WriteLine($"D1 + D2 = {D3.ToString()}");
Console.WriteLine();

D3 = D1 + 7800;
Console.WriteLine($"D1 + 7800 = {D3.ToString()}");
Console.WriteLine();

D3 = 666 + D1 ;
Console.WriteLine($"666 + D1 = {D3.ToString()}");
Console.WriteLine();

Console.WriteLine("D3 = D1++");
D3 =  D1++;
Console.WriteLine($"D3 = {D3.ToString()}");
Console.WriteLine($"D1 = {D1.ToString()}");
Console.WriteLine();

Console.WriteLine("D3 = --D2");
D3 = --D2;
Console.WriteLine($"D3 = {D3.ToString()}");
Console.WriteLine($"D2 = {D2.ToString()}");
Console.WriteLine();

if (D1 > D2)
{
    Console.WriteLine("D1 > D2 is True");
} else
{
    Console.WriteLine("D1 > D2 is False");
}

Console.WriteLine();

if (D1 <= D2)
{
    Console.WriteLine("D1 <= D2 is True");
} else
{
    Console.WriteLine("D1 <= D2 is False");
}

if (D1)
{
    Console.WriteLine("D1 is not null");
} else
{
    Console.WriteLine("D1 is null");
}

DateTime obj = (DateTime)D1;
Console.WriteLine(obj.ToString());
