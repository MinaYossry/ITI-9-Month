using System.Linq;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = string.Join(" ", input.Split(" ").Reverse());
            Console.WriteLine(output);
        }
    }
}