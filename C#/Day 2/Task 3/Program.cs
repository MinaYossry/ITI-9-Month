using System.Diagnostics;
using System.Numerics;

namespace Task_3
{
    internal class Program
    {
        static double byString(int end)
        {
            int count = 0;
            for (int i = 0; i < end; i++)
            {
                string str = i.ToString();
                foreach (char item in str)
                {
                    if (item == '1')
                        count++;
                }
            }
            return count;
        }

        static double byMath(int end)
        {
            int count = 0;
            for (int i = 0; i < end; i++)
            {
                int number = i;
                while (number != 0)
                {
                    if (number % 10 == 1)
                        ++count;
                    number /= 10;
                }
            }
            return count;
        }

        static double byEq(int end)
        {
            string n = end.ToString();
            int numberOfZeros = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == '0')
                    numberOfZeros++;
            }
            return numberOfZeros * Math.Pow(10, numberOfZeros-1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n=======================================================\n");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //int count = byString();

            Console.WriteLine($"By String: Total number of 1s: {byString((int)Math.Pow(10,8))}");

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine("\n=======================================================\n");
            stopWatch = new Stopwatch();
            stopWatch.Start();
            //int count = byString();

            Console.WriteLine($"By Math: Total number of 1s: {byMath((int)Math.Pow(10, 8))}");

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine("\n=======================================================\n");
            stopWatch = new Stopwatch();
            stopWatch.Start();
            //int count = byString();

            Console.WriteLine($"By Eq: Total number of 1s: {byEq((int)Math.Pow(10, 8))}");

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.WriteLine("\n=======================================================\n");
        }
    }
}