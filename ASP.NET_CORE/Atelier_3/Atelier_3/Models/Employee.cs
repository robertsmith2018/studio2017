using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string firstName, string lastName, DateTime hireDate, string department, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HireDate = hireDate;
            Department = department;
            Salary = salary;
        }
    }
}
