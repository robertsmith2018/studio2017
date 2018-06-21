using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atelier_5.Models;

namespace Atelier_5.Controllers
{
    public class HomeController : Controller
    {
        private db_cgodinContext context;
        public HomeController(db_cgodinContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            //Trouver toutes les données de la table Customers
            List<TblCustomers> customers = context.TblCustomers.ToList();

            // affichage en format HTML
            string body = "<table border=1>";
            foreach (var c in customers)
            {
                body += "<tr>";
                body += "<td>" + c.CustomerName + "</td>";
                body += "<td>" + c.Country + "</td>";
                body += "<td>" + c.CreationDate?.ToString("yyyy-MM-dd") + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }

        public IActionResult CustomersByCountry(string country)
        {

            //Trouver tous les clients 
            List<TblCustomers> customers = context.TblCustomers.ToList();

            //une requete LINQ pour les clients d'un pays donné
            var req = from c in customers
                      where (c.Country.ToUpper()).Equals(country.ToUpper())
                      select c;

            // affichage en format HTML
            string body = "<table border=1>";
            foreach (var c in req.ToList())
            {
                body += "<tr>";
                body += "<td>" + c.CustomerName + "</td>";
                body += "<td>" + c.Country + "</td>";
                body += "<td>" + c.CreationDate?.ToString("yyyy-MM-dd") + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }

        public IActionResult RecentCustomers()
        {
            //Trouver tous les clients 
            List<TblCustomers> customers = context.TblCustomers.ToList();

            //Recuperer la date d'une annee passee
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            DateTime lastDate = new DateTime(year - 1, month, day);

            //une requete LINQ pour les nouveaux clients
            var req = from c in customers
                      where c.CreationDate.Value > lastDate
                      select c;

            // affichage en format HTML
            string body = "<table border=1>";
            foreach (var c in req.ToList())
            {
                body += "<tr>";
                body += "<td>" + c.CustomerName + "</td>";
                body += "<td>" + c.Country + "</td>";
                body += "<td>" + c.CreationDate?.ToString("yyyy-MM-dd") + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");

        }


        public IActionResult OrdersByCustomer(int id)
        {
            //Trouver toutes les commandes
            List<TblOrders> orders = context.TblOrders.ToList();

            //une requete LINQ pour les commandes d'un client donné
            var req = from o in orders
                      where (o.CustomerId == id)
                      select o;

            // affichage en format HTML
            //table

            string body = "<h1>" + context.TblCustomers.Find(id).CustomerName + "</h1>";
            body += "<table border=1>";
            foreach (var o in req.ToList())
            {
                body += "<tr>";
                body += "<td>" + o.OrderDate?.ToString("yyyy-MM-dd") + "</td>";
                body += "<td>" + o.Amount + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }

        public IActionResult CurrentOrders()
        {
            //Recuperer la date d'une annee courante
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            //Trouver toutes les commandes
            List<TblOrders> orders = context.TblOrders.ToList();

            var req = from o in orders
                      where (o.OrderDate.Value.Month == month)
                               && (o.OrderDate.Value.Year == year)
                      select o;
            // affichage en format HTML
            //table
            string body = "<table border=1>";
            foreach (var o in req.ToList())
            {
                body += "<tr>";
                body += "<td>" + o.OrderDate?.ToString("yyyy-MM-dd") + "</td>";
                body += "<td>" + o.Amount + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }

        public IActionResult AddNewOrder(int customerid, DateTime orderdate, decimal amount)
        {
            //construire une nouvelle commande avec les paramètres passés.
            TblOrders order = new TblOrders();
            order.Amount = amount;
            order.OrderDate = orderdate;
            order.CustomerId = customerid;

            //ajouter cette nouvelle commande
            context.Add(order);
            context.SaveChanges();

            return RedirectToAction("CurrentOrders");
        }

        public IActionResult DeleteOrdersLessThan(decimal amount)
        {
            //Trouver toutes les commandes
            List<TblOrders> orders = context.TblOrders.ToList();
            foreach (var o in orders)
            {
                if (o.Amount < amount)
                {
                    context.Remove(o);
                }
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseAmountForOrder(int orderid, decimal amount)
        {
            //Trouver toutes les commandes
            List<TblOrders> orders = context.TblOrders.ToList();

            //trouver la commande avec l'id = orderid
            var req = from o in orders
                        where o.OrderId == orderid
                        select o;

            TblOrders order = req.FirstOrDefault();
            order.Amount += amount;

            context.Update(order);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
