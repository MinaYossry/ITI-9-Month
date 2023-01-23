using System.Diagnostics.CodeAnalysis;

namespace Task01
{
    public struct HiringDate
    {
        int day;
        int month;
        int year;

        public HiringDate(int _day, int _month, int _year)
        {
            day = _day;
            month = _month;
            year = _year;
        }

        public HiringDate()
        {
            string[] dateString;
            int _day ;
            int _month;
            int _year;
            do
            {
                Console.Write("Enter Hire Date: ");
                dateString = Console.ReadLine().Split('-');
            } while (!(int.TryParse(dateString[0], out _day)) || _day < 1 || _day > 31 ||
                     !(int.TryParse(dateString[1], out _month)) || _month < 1 || _month > 12 ||
                     !(int.TryParse(dateString[2], out _year)) || _year < 2000 || _year > 2022);
            

            year = _year;
            month = _month;
            day = _day;
        }

        public int Day { get { return day; } set { day = value; } }
        public int Month { get { return month; } set { month = value; } }
        public int Year { get { return year;} set { year = value; } }

        public override string ToString()
        {
            return $"HireDate: {day}-{month}-{year}";
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return day == ((HiringDate) obj).Day && month == ((HiringDate)obj).Month && year == ((HiringDate)obj).Year;
        }
    }
}
