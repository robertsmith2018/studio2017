using System;
using System.Collections.Generic;

namespace Atelier_5.Models
{
    public partial class TblCustomers
    {
        public TblCustomers()
        {
            TblOrders = new HashSet<TblOrders>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public DateTime? CreationDate { get; set; }

        public ICollection<TblOrders> TblOrders { get; set; }
    }
}
