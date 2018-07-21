using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atelier_6.Models;

namespace Atelier_6.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext context;
        public HomeController(SchoolContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            //trouver la liste des étudiants
            List<Student> students = context.Students.ToList();

            return View(students);
            /*
            //affichage en HTML
            string body = "<table border=1>";
            foreach (var s in students)
            {
                body += "<tr>";
                body += "<td>" + s.LastName + "</td>";
                body += "<td>" + s.FirstMidName + "</td>";
                body += "<td>" + s.EnrollmentDate?.ToString("dd-MM-yyyy") + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
            */
        }


        //affichage du formulaire
        [HttpGet]
        [ActionName("Create")]
        public IActionResult CreateStudent()
        {
            return View();
        }

        //traitement du formulaire
        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreateStudent([Bind(include: "LastName, FirstMidName, EnrollmentDate")]Student s)
        {
            if (ModelState.IsValid)
            {
                context.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //affichage du formulaire
        [HttpGet]
    
        public IActionResult EditStudent(int id)
        {
            Student s = context.Students.Find(id);
            return View(s);
        }

        //traitement du formulaire
        [HttpPost]
        public IActionResult EditStudent(int ID, [Bind(include: "LastName, FirstMidName, EnrollmentDate")]Student s)
        {
            if (ModelState.IsValid)
            {
                s.ID = ID;
                context.Update(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student s = context.Students.Find(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult DeleteStudent(Student s)
        {
            context.Remove(s);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddEnrollment(int id)
        {
            List<Course> courses = context.Courses.ToList();
            ViewBag.courses = courses;
            ViewBag.StudentID = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddEnrollment([Bind(include: "CourseID, StudentID, Grade")]Enrollment e)
        {
            if (ModelState.IsValid)
            {
                context.Add(e);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult AddEnrollments()
        {
            if (context.Enrollments.Any())
            {
                return RedirectToAction("Index");
            }

            //trouver la liste des étudiants et des cours
            List<Student> students = context.Students.ToList();
            List<Course> courses = context.Courses.ToList();

            //ajout de quelques inscriptions

            //cours avec ID - AEC-420-107
            Enrollment e1 = new Enrollment()
            {
                CourseID = courses[0].CourseID,
                StudentID = students[0].ID,
                Grade = Grade.A
            };
            Enrollment e2 = new Enrollment()
            {
                CourseID = courses[0].CourseID,
                StudentID = students[1].ID,
                Grade = Grade.B
            };
            Enrollment e3 = new Enrollment()
            {
                CourseID = courses[0].CourseID,
                StudentID = students[2].ID,
                Grade = Grade.F
            };
            //cours avec ID - AEC-420-110
            Enrollment e4 = new Enrollment()
            {
                CourseID = courses[3].CourseID,
                StudentID = students[0].ID,
                Grade = Grade.F
            };
            Enrollment e5 = new Enrollment()
            {
                CourseID = courses[3].CourseID,
                StudentID = students[2].ID,
                Grade = Grade.D
            };
            //cours avec ID - AEC-420-109
            Enrollment e6 = new Enrollment()
            {
                CourseID = courses[2].CourseID,
                StudentID = students[1].ID,
                Grade = Grade.D
            };
            Enrollment e7 = new Enrollment()
            {
                CourseID = courses[2].CourseID,
                StudentID = students[2].ID,
                Grade = Grade.A
            };

            context.Add(e1);
            context.Add(e2);
            context.Add(e3);
            context.Add(e4);
            context.Add(e5);
            context.Add(e6);
            context.Add(e7);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RecentStudents()
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            DateTime lastyear = new DateTime(year - 1, month, day);
            
            //trouver la liste des étudiants inscrits recemment
            List<Student> students = context.Students.Where(s => s.EnrollmentDate > lastyear).ToList();

            //affichage en HTML
            string body = "<table border=1>";
            foreach (var s in students)
            {
                body += "<tr>";
                body += "<td>" + s.LastName + "</td>";
                body += "<td>" + s.FirstMidName + "</td>";
                body += "<td>" + s.EnrollmentDate?.ToString("dd-MM-yyyy") + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }


        public IActionResult EnrollmentsByStudent(int id)
        {
            //trouver toutes les inscriptions d'un étudiant avec son ID
            Student student = context.Students.Find(id);
            List<Enrollment> enrollments = student.Enrollments.ToList();

            //affichage en HTML
            string body = "<h2>Les inscriptions de " +
                            student.FirstMidName + " " +
                            student.LastName + "</h2>";
             
            body += "<table border=1>";
            foreach (var e in enrollments)
            {
                body += "<tr>";
                body += "<td>" + e.Course.Title + "</td>";
                body += "<td>" + e.Grade + "</td>";
                body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }

        public IActionResult FailedCourses(int id)
        {
            //trouver toutes les inscriptions d'un étudiant avec son ID
            Student student = context.Students.Find(id);
            List<Enrollment> enrollments = student.Enrollments.
                                                Where(e=>e.Grade == Grade.F).ToList();

            //affichage en HTML
            string body = "<h2>Les cours échoués par " +
                            student.FirstMidName + " " +
                            student.LastName + "</h2>";

            body += "<table border=1>";
            foreach (var e in enrollments)
            {
                    body += "<tr>";
                    body += "<td>" + e.Course.Title + "</td>";
                    body += "<td>" + e.Grade + "</td>";
                    body += "</tr>";
            }
            body += "</table>";
            return Content(body, "text/html");
        }
    }
}
