using L2O___D09;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D10
{

    internal class CustomStringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return x.ToUpper().CompareTo(y.ToUpper());
        }
    }

    internal class CustomSameLettersComparer : IEqualityComparer<string>
    {


        public bool Equals(string? x, string? y)
        {
            var left = x?.ToList();
            left?.Sort();
            var right = y?.ToList();
            right?.Sort();

            if (left is not null && right is not null)
            {
                x = string.Join("", left);
                y = string.Join("", right);
                return x == y;
            }

            return false;
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return base.GetHashCode();
        }
    }

}
