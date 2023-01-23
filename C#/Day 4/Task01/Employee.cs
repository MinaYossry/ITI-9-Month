using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task01
{
    public enum Gender:byte
    {
        MALE,
        FEMALE
    }

    [Flags]
    public enum SecurityLevel:byte
    {
        GUEST = 0b_0000_0100,
        DEVELOPER = 0b_0000_0111,
        SECRETARY = 0b_0000_0110,
        DBA = 0b_0000_1110,
        OFFICER = 0b_0000_1111
    }

    public class EmployeeSearch
    {
        Employee[] Employees;
        int[] nationalIds;
        HiringDate[] hiringDates;
        string[] names;
        readonly int size;

        public int Size { get { return size; } } 

        public EmployeeSearch(int _size)
        {
            size = _size;
            Employees = new Employee[size];
            nationalIds = new int[size];
            hiringDates = new HiringDate[size];
            names = new string[size];
        }

        public Employee this[int index, int id, HiringDate hiringDate, string name]
        {
            set
            {
                    Employees[index] = (value);
                    nationalIds[index] = (id);
                    hiringDates[index] = (hiringDate);
                    names[index] = (name);
            }

        }

        public Employee? this[string name]
        {
            get
            {
                for (int i = 0; i < names?.Length; i++)
                {
                    if (names[i] == name)
                        return Employees[i];
                }
                return null;

            }
        }


        public Employee? this[int id]
        {
            get
            {
                for (int i = 0; i < nationalIds?.Length; i++)
                {
                    if (nationalIds[i] == id)
                        return Employees[i];
                }
                return null;

            }

        }

        public Employee? this[HiringDate hireDate]
        {
            get
            {
                for (int i = 0; i < hiringDates?.Length; i++)
                {
                    if (hiringDates[i].Equals(hireDate))
                        return Employees[i];
                }
                return null;
            }
        }


    }

    public struct Employee
    {
        int id;
        string name;
        SecurityLevel securityLevel;
        decimal salary;
        HiringDate hireDate;
        Gender gender;

        public Employee(int _ID, SecurityLevel _securityLevel, decimal _salary, HiringDate _hireDate, Gender _gender, string _name)
        {
            id = _ID;
            securityLevel = _securityLevel;
            salary = _salary;
            hireDate = _hireDate;
            gender = _gender;
            name = _name;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public SecurityLevel SecurityLevel { get { return securityLevel; } set { securityLevel = value; } }
        public decimal Salary { get { return salary; } set { salary = value; } }
        public HiringDate HireDate { get { return hireDate; } set { hireDate = value; } }
        public Gender Gender { get { return gender; } set { gender = value; } }

        public override string ToString()
        {
            return $"""
                =======================================================
                ID: {id}
                Name: {name}
                SecurityLevel : {securityLevel}
                Salary : {string.Format("{0:C}", salary)}
                {hireDate}
                Gender : {gender}
                =======================================================

                """;
        }



    }
}
