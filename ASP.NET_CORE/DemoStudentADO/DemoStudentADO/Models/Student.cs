using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStudentADO.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double NoteFinale { get; set; }

        public Student()
        {

        }

        public Student(int id, string firstName, string lastName, double noteFinale)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NoteFinale = noteFinale;
        }
    }
}
