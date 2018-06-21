using System;
using System.Collections.Generic;

namespace Atelier_5.Models
{
    public partial class TblOrders
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Amount { get; set; }

        public TblCustomers Customer { get; set; }
        public TblOrders Order { get; set; }
        public TblOrders InverseOrder { get; set; }
    }
}
