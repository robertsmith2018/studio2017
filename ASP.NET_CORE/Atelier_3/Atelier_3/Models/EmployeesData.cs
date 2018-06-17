using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_3.Models
{
    public class EmployeesData
    {
        //  public List<Employee> employees { get; set; }
        public List<Employee> employees;
        public EmployeesData()
        {
            employees = new List<Employee>();
            employees.Add(new Employee(1,"Felix", "Bedard", new DateTime(2000,05,02), "IT", 45000));
            employees.Add(new Employee(2, "Sam", "Lalonde", new DateTime(2014, 11, 12), "Marketing", 60000));
            employees.Add(new Employee(3, "Ben", "Lam", new DateTime(1995, 05, 17), "Accounting", 35000));
            employees.Add(new Employee(4, "Annie", "Desroches", new DateTime(2005, 01, 15), "Marketing", 82000));
            employees.Add(new Employee(5, "Myriam", "Couillard", new DateTime(1995, 10, 12), "Marketing", 65000));
            employees.Add(new Employee(6, "John", "Trudeau", new DateTime(2009, 12, 08), "Accounting", 28000));
            employees.Add(new Employee(7, "Joanne", "Brossard", new DateTime(2013, 03, 14), "IT", 95000));
            employees.Add(new Employee(8, "Alex", "Lalonde", new DateTime(2012, 03, 14), "Marketing", 65000));
        }
    }
}
