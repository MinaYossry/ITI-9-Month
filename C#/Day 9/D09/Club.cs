using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    public class Club
    {
        public Club() {
            Members = new();
        }
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> Members { get; set; }
        public void AddMember(Employee E)
        {
            if (E is not null && !Members.Contains(E))
            {
                Members.Add(E);
                E.EmployeeLayOff += RemoveMember;
            }
            ///Try Register for EmployeeLayOff Event Here
        }
        ///CallBackMethod
        public void RemoveMember (object sender, EmployeeLayOffEventArgs e)
        {
            ///Employee Will not be removed from the Club if Age>60
            ///Employee will be removed from Club if Vacation Stock < 0

            if (e.Cause != LayOffCause.Age && sender is not BoardMember)
            {
                Employee emp = sender as Employee;

                if (emp is not null)
                {
                    Members.Remove(emp);
                    emp.EmployeeLayOff -= RemoveMember;
                    Console.WriteLine($"Employee {emp.EmployeeID} is removed from club {ClubName} because of {e.Cause}");
                }
   
            }
        }
    }
}
