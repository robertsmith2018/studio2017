using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atelier_4.Models;

namespace Atelier_4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<Customer> customers = customerDAL.GetCustomers().ToList();
            //affichage sous forme d'une table
            string body = "<table border=1>";
            foreach (Customer c in customers)
            {
                body += "<tr>";
                body += "<td>" + c.CustomerName + " | " +
                        c.Country + " | " +
                        c.CreationDate.ToString("dd-MM-yyyy") +
                        "</td>";
                body += "</tr>";
            }
            body += "</table>";

            return Content(body, "text/html");
        }

        public IActionResult AddCustomer(string customername, string country, DateTime creationDate)
        {
            Customer c = new Customer(customername, country, creationDate);
            CustomerDAL customerDAL = new CustomerDAL();
            customerDAL.AddCustomer(c);

            return RedirectToAction("Index");
        }


        public IActionResult GetOrders(int customerid)
        {
            OrderDAL orderDAL = new OrderDAL();
            List<Order> orders = orderDAL.GetOrdersByCustomer(customerid).ToList();
            //affichage sous forme d'une table
            string body = "<table border=1>";
            foreach (Order o in orders)
            {
                body += "<tr>";
                body += "<td>" + o.Customer.CustomerName + " | " +
                        o.OrderDate.ToString("dd-MM-yyyy") + " | " +
                        o.Amount +
                        "</td>";
                body += "</tr>";
            }
            body += "</table>";

            return Content(body, "text/html");
        }

        public IActionResult AddOrder(int customerid, DateTime orderdate, double amount)
        {
            OrderDAL orderDAL = new OrderDAL();
            CustomerDAL customerDAL = new CustomerDAL();
            /* recuperer tous les nouveaux clients*/
            List<Customer> newcustomers = customerDAL.GetNewCustomers().ToList();
            
            /*trouver si le client en cours est nouveau, il aura alors 5% de rabais*/
            foreach (Customer c in newcustomers)
            {
                if(c.CustomerID == customerid)
                {
                    amount = amount * 0.95;
                    break;
                }
            }

            orderDAL.AddOrder(customerid, orderdate, amount);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateOrder(int orderid, DateTime orderdate, double amount)
        {
            OrderDAL orderDAL = new OrderDAL();
            orderDAL.UpdateOrder(orderid, orderdate, amount);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int orderid)
        {
            OrderDAL orderDAL = new OrderDAL();
            orderDAL.DeleteOrder(orderid);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrdersBefore(DateTime orderdate)
        {
            OrderDAL orderDAL = new OrderDAL();
            orderDAL.DeleteOrdersBefore(orderdate);

            return RedirectToAction("Index");
        }

        public IActionResult NewCustomers()
        {
            CustomerDAL customerDAL = new CustomerDAL();
            List<Customer> customers = customerDAL.GetNewCustomers().ToList();
            //affichage sous forme d'une table
            string body = "<table border=1>";
            foreach (Customer c in customers)
            {
                body += "<tr>";
                body += "<td>" + c.CustomerName + " | " +
                        c.Country + " | " +
                        c.CreationDate.ToString("dd-MM-yyyy") +
                        "</td>";
                body += "</tr>";
            }
            body += "</table>";

            return Content(body, "text/html");
        }
    }
}
