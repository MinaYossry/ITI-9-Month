// See https://aka.ms/new-console-template for more information
using MathClass;

MathC m = new MathC();

Console.WriteLine($"10 + 5: = {m.Add(10,5)}");
Console.WriteLine($"10 - 5: = {m.Subtract(10, 5)}");
Console.WriteLine($"10 * 5: = {m.Multiply(10, 5)}");
Console.WriteLine($"10 / 5: = {m.Divide(10, 5)}");

Console.WriteLine("\nWith Static methods");

Console.WriteLine($"10 + 5: = {MathS.Add(10, 5)}");
Console.WriteLine($"10 - 5: = {MathS.Subtract(10, 5)}");
Console.WriteLine($"10 * 5: = {MathS.Multiply(10, 5)}");
Console.WriteLine($"10 / 5: = {MathS.Divide(10, 5)}");