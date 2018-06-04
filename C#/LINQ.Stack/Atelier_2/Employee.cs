using System;
using System.Collections.Generic;
using System.Text;

namespace Atelier_2
{
    class Employee
    {
        public string Name { get; set; }
        public DateTime Hiredate { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(string name, DateTime hiredate, string department, double salary)
        {
            Name = name;
            Hiredate = hiredate;
            Department = department;
            Salary = salary;
        }


    }
}
