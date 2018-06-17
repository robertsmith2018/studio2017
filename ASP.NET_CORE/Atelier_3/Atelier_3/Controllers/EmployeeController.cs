using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atelier_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atelier_3.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeesData data = new EmployeesData();

        public IActionResult Index()
        {
            string output = "<table border=1>";
            foreach (Employee e in data.employees)
            {
                output += "<tr>";
                output += "<td>" + e.Id + "</td>";
                output += "<td>" + e.FirstName + "</td>";
                output += "<td>" + e.LastName + "</td>";
                output += "</tr>";
            }
            output += "</table>";
            return Content(output, "text/html");
        }

        public IActionResult SalaryMoreThan(double value)
        {
            /*Version sans LINQ
             * List<Employee> results = new List<Employee>();
            foreach(Employee e in data.employees)
            {
                if(e.Salary >= value)
                {
                    results.Add(e);
                }
            }*/

            var req = from e in data.employees
                      where e.Salary >= value
                      select e;

            string output = "<table border=1>";
            foreach (Employee e in req)
            {
                output += "<tr>";
                output += "<td>" + e.Id + "</td>";
                output += "<td>" + e.FirstName + "</td>";
                output += "<td>" + e.LastName + "</td>";
                output += "<td>" + e.Salary + "</td>";
                output += "</tr>";
            }
            output += "</table>";
            return Content(output, "text/html");
        }

        public IActionResult Department(string name)
        {
            var req = from e in data.employees
                      where e.Department.ToUpper().Equals(name.ToUpper())
                      select e;

            string output = "<table border=1>";
            foreach (Employee e in req)
            {
                output += "<tr>";
                output += "<td>" + e.Id + "</td>";
                output += "<td>" + e.FirstName + "</td>";
                output += "<td>" + e.LastName + "</td>";
                output += "<td>" + e.Department+ "</td>";
                output += "</tr>";
            }
            output += "</table>";
            return Content(output, "text/html");
        }

        public IActionResult EmployeeDetails(int id)
        {
            var req = from e in data.employees
                      where e.Id == id
                      select e;

            string output = "<table border=1>";
            foreach (Employee e in req)
            {
                output += "<tr>";
                output += "<td>" + e.Id + "</td>";
                output += "<td>" + e.FirstName + "</td>";
                output += "<td>" + e.LastName + "</td>";
                output += "<td>" + e.Department + "</td>";
                output += "<td>" + e.HireDate.Day + "/" + e.HireDate.Month + "/" + e.HireDate.Year + "</td>";
                output += "<td>" + e.Salary + "</td>";
                output += "</tr>";
            }
            output += "</table>";
            return Content(output, "text/html");
        }

        public IActionResult EmployeesByName(string lastname)
        {
            var req = from e in data.employees
                      where e.LastName.ToUpper().Equals(lastname.ToUpper())
                      select e;

            string output = "<table border=1>";
            foreach (Employee e in req)
            {
                output += "<tr>";
                output += "<td>" + e.Id + "</td>";
                output += "<td>" + e.FirstName + "</td>";
                output += "<td>" + e.LastName + "</td>";
                output += "<td>" + e.Department + "</td>";
                output += "<td>" + e.HireDate.Day + "/" + e.HireDate.Month + "/" + e.HireDate.Year + "</td>";
                output += "<td>" + e.Salary + "</td>";
                output += "</tr>";
            }
            output += "</table>";
            return Content(output, "text/html");
        }
    }
}