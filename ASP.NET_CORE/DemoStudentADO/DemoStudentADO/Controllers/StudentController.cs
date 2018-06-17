using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStudentADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoStudentADO.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL studentDAL = new StudentDAL();

        public IActionResult Index()
        {
            List<Student> students = studentDAL.GetAllStudents().ToList();
            string body = "";
            foreach (Student s in students)
            {
                body += s.FirstName + " | " + s.LastName + " | " + s.NoteFinale + "<br />";
            }

            return Content(body, "text/html");
        }
        public IActionResult Add(string firstname, string lastname, double notefinale)
        {

            Student student = new Student();
            student.FirstName = firstname;
            student.LastName = lastname;
            student.NoteFinale = notefinale;

            studentDAL.AddStudent(student);

            return RedirectToAction("Index");
        }
    }
}