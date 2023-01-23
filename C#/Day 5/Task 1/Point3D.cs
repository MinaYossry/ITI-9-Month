using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D()
        {
            int input;
            do
            {
                Console.Write("X: ");
            } while (!int.TryParse(Console.ReadLine(), out input));
            X = input;

            do
            {
                Console.Write("Y: ");
            } while(!int.TryParse(Console.ReadLine(), out input));
            Y = input;


            do
            {
                Console.Write("Z: ");
            } while (!int.TryParse(Console.ReadLine(), out input));
            Z = input;
        }
        public Point3D(int x = 0, int y = 0, int z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point Coordinates:   ({X}, {Y}, {Z})";
        }

        public static explicit operator string(Point3D de)
        { return de.ToString(); }

        //public static bool operator ==(Point3D a, Point3D b)
        //{
        //    if (a is not null && a is not null)
        //        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        //    return false;
        //}

        //public static bool operator != (Point3D a, Point3D b)
        //{
        //    return !(a == b);
        //}

        public override bool Equals(object? obj)
        {
            Point3D? P = (Point3D?)obj;

            return P != null && X == P.X && Y == P.Y && Z == P.Z;
        }
    }
}
