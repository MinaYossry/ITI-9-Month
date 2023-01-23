using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClass
{
    public class MathC
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public double Divide(int x, int y)
        {
            return (double)x / y;
        }
    }

    static class MathS
    {
        static public int Add(int x, int y)
        {
            return x + y;
        }

        static public int Subtract(int x, int y)
        {
            return x - y;
        }

        static public int Multiply(int x, int y)
        {
            return x * y;
        }

        static public double Divide(int x, int y)
        {
            if (y == 0)
                return (double)x / y;
            return 0;
        }
    }
}
