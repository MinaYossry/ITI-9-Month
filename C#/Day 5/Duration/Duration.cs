using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurationName
{
    internal class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int seconds)
        {
            Hours= seconds / 3600;
            seconds %= 3600;
            Minutes = seconds / 60;
            Seconds = seconds % 60;
        }

        public override bool Equals(object? obj)
        {
            Duration? D = (Duration?)obj;

            return D != null && Hours == D.Hours && Minutes == D.Minutes && Seconds == D.Seconds;
        }

        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public static Duration operator+(Duration a, Duration b)
        {
            return new(
                (a?.Hours ?? 0) + (b?.Hours?? 0),
                (a?.Minutes ?? 0) + (b?.Minutes ?? 0),
                (a?.Seconds ?? 0) + (b?.Seconds ?? 0)
            );
        }

        public static Duration operator+(int seconds, Duration b)
        {
            return new Duration(seconds) + b;

            //int hours = seconds / 3600;
            //seconds %= 3600;
            //int minutes = seconds / 60;
            //seconds %= 60;

            //return new(
            //    b?.Hours?? 0+ hours,
            //    b?.Minutes?? 0 + minutes,
            //    b?.Seconds?? 0 + seconds
            //);
        }

        public static Duration operator+(Duration a, int seconds)
        {
            return a + new Duration(seconds);

            //int hours = seconds / 3600;
            //seconds %= 3600;
            //int minutes = seconds / 60;
            //seconds %= 60;

            //return new(
            //    a?.Hours ?? 0+ hours,
            //    a?.Minutes ?? 0 + minutes,
            //    a?.Seconds ?? 0 + seconds
            //);
        }

        public static Duration operator++(Duration a)
        {
            Duration newD = new(
                (a?.Hours ?? 0),
                (a?.Minutes ?? 0) + 1,
                (a?.Seconds ?? 0)
            );

            if (newD.Minutes == 60)
            {
                newD.Hours++;
                newD.Minutes = 0;
            }

            return newD;
        }

        public static Duration operator--(Duration a)
        {
            Duration newD = new(
                (a?.Hours ?? 0),
                (a?.Minutes ?? 0) - 1,
                (a?.Seconds ?? 0)
            );

            if (newD.Minutes == -1)
            {
                newD.Hours--;
                newD.Minutes = 59;
            }

            return newD;
        }

        public static Duration operator-(Duration a, Duration b)
        {
            return new(
                (a?.Hours ?? 0) - (b?.Hours ?? 0),
                (a?.Minutes ?? 0) - (b?.Minutes ?? 0),
                (a?.Seconds ?? 0) - (b?.Seconds ?? 0)
            );
        }

        public static bool operator> (Duration a, Duration b)
        {
            if (a != null && b != null)
                return a.Hours > b.Hours ||
                       (a.Hours == b.Hours && a.Minutes > b.Minutes) ||
                       (a.Hours == b.Hours && a.Minutes == b.Minutes &&  a.Seconds > b.Seconds);

            return false;
        }

        public static bool operator <(Duration a, Duration b)
        {
            if (a != null && b != null)
                return a.Hours < b.Hours ||
                       (a.Hours == b.Hours && a.Minutes < b.Minutes) ||
                       (a.Hours == b.Hours && a.Minutes == b.Minutes && a.Seconds < b.Seconds);

            return false;
        }

        public static bool operator <=(Duration a, Duration b)
        {
            if (a != null && b != null)
                return (a < b) || a.Equals(b);

            return false;
        }

        public static bool operator >=(Duration a, Duration b)
        {
            if (a != null && b != null)
                return (a > b) || a.Equals(b);

            return false;
        }

        public static implicit operator bool(Duration a)
        {
            return a != null;
        }

        public static explicit operator DateTime(Duration a)
        {
            DateTime output = new DateTime(2023,1,23,a.Hours,a.Minutes,a.Seconds);

            return output;
        }
    }
}
