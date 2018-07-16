using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atelier_7.Models;

namespace Atelier_7.Controllers
{
    public class HomeController : Controller
    {
        private DataManager dataManager;

        public HomeController()
        {
            dataManager = new DataManager();
        }

        public IActionResult Index()
        {
            List<Department> departments = dataManager.Departments;
            return View(departments);
        }

        //Index2 pour genere la vue automatiquemet avec Razor
        public IActionResult Index2()
        {
            List<Department> departments = dataManager.Departments;
            return View(departments);
        }

        public IActionResult Index3()
        {
            List<Department> departments = dataManager.Departments;
            return View(departments);
        }

        public IActionResult Employees()
        {
            List<Employee> employees = dataManager.Employees;
            return View(employees);
        }

        public IActionResult EmployeesByDept(int id)
        {
            List<Employee> selected_employees = dataManager.Employees
                                        .Where(e => e.DepartmentID == id).ToList();
            return View(selected_employees);
        }

        public IActionResult Details(int id)
        {
           Employee employee = dataManager.Employees.Find(e => e.ID == id);
                string deptName = dataManager.Departments.Find(d => d.ID == employee.DepartmentID).Name;
                ViewBag.nom_du_departement = deptName;
           return View(employee);

        }
    }
}
