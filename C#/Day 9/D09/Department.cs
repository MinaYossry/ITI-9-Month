using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    public class Department
    {
        public Department() {
            Staff = new();
        }
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff { get; set; }
        public void AddStaff(Employee E)
        {
            ///Try Register for EmployeeLayOff Event Here
            if (E is not null && !Staff.Contains(E))
            {
                Staff.Add(E);
                E.EmployeeLayOff += RemoveStaff;
            }
        }

        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            Employee emp = sender as Employee;

            if (emp is not null)
            {
                Staff.Remove(emp);
                emp.EmployeeLayOff -= RemoveStaff;
                Console.WriteLine($"Employee {emp.EmployeeID} is removed from department {DeptName} because of {e.Cause}");
            }
        }
    }
}
