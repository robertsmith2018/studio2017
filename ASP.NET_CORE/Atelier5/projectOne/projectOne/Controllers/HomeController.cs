using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projectOne.Models;

namespace projectOne.Controllers
{
    public class HomeController : Controller
    {
        private dbcgodinContext context;
        public HomeController(dbcgodinContext _context)
        {
            context = _context;
        }


        public IActionResult Index()
        {
            string body = "<table border=1";
            foreach(var client in context.TblCustomers)
            {
                body += "<tr>";
                body += "<td>" + client.CustomerName + "</td>";
                body += "<td>" + client.Country + "</td>";
                body += "<td>" + client.CreationDate?.ToString("yyyy-MM-dd") + "</td>";
                body += "<tr>";

            }
            body += "</table>";
            return Content(body, "text/html");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
