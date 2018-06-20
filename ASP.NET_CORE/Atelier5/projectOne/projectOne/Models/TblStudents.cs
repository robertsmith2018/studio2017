using System;
using System.Collections.Generic;

namespace projectOne.Models
{
    public partial class TblStudents
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal? Notefinale { get; set; }
    }
}
