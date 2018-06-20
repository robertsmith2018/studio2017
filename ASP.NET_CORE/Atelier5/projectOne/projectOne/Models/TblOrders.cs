using System;
using System.Collections.Generic;

namespace projectOne.Models
{
    public partial class TblOrders
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Amount { get; set; }

        public TblCustomers Customer { get; set; }
    }
}
