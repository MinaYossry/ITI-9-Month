using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; init; }
        public DateTime BirthDate { get; init; }
        public int VacationStock { get; set; }
        public bool RequestVacation(DateTime From, DateTime To)
        {
            double totalDays = (To - From).TotalDays;
            if (totalDays <= VacationStock)
            {
                VacationStock -= (int)totalDays;
                return true;
            } 
            else
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.VacationStock });
                return false;
            }
        }
        public void EndOfYearOperation(int year)
        {
            if (year - BirthDate.Year >= 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.Age });
            }
        }
    }

}
