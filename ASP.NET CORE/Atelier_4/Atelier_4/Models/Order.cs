using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_4.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        /* relation one to many*/
        public Customer Customer { get; set; }

        public Order()
        {
        }

        public Order(DateTime orderDate, double amount, Customer customer)
        {
            OrderDate = orderDate;
            Amount = amount;
            Customer = customer;
        }

        public Order(int orderID, DateTime orderDate, double amount, Customer customer)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            Amount = amount;
            Customer = customer;
        }
    }
}
