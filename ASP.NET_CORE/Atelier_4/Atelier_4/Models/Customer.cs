using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_4.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public DateTime CreationDate { get; set; }

        public Customer()
        {
        }

        public Customer(int customerID)
        {
            CustomerID = customerID;
        }

        public Customer(string customerName, string country, DateTime creationDate)
        {
            CustomerName = customerName;
            Country = country;
            CreationDate = creationDate;
        }

        public Customer(int customerID, string customerName, string country, DateTime creationDate)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            Country = country;
            CreationDate = creationDate;
        }
    }
}
