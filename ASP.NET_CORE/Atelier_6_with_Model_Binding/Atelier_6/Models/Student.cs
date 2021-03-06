﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_6.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
