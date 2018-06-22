using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atelier_6.Models;

namespace Atelier_6.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext context;
        public HomeController(SchoolContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            //trouver la liste des étudiants
            List<Student> students = context.Students.ToList();

            //affichage en HTML
            string body = "<table border=1>";
            foreach (var s in students)
            {
                body += "<tr>";
                body += "<td>" + s.LastName + "</td>";
                body += "<td>" + s.FirstMidName + "</td>";
                body += "<td>" + s.EnrollmentDate?.ToString("dd-MM-yyyy") + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }
    }
}
