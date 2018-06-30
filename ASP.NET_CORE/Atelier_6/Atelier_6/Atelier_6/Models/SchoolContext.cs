using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_6.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            AddDataToDatabase();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        public void AddDataToDatabase()
        {
            //remplir la base avec un jeu de test
            Database.EnsureCreated();
            //verifier s'il y a des données existants
            if (Students.Any() || Courses.Any())
            {
                return;
            }
            //ajout des étudiants
            Student s1 = new Student()
            {
                LastName = "Beaudoin",
                FirstMidName = "Guillaume",
                EnrollmentDate = new DateTime(2018, 01, 15)
            };
            Student s2 = new Student()
            {
                LastName = "Lam",
                FirstMidName = "Benjamin",
                EnrollmentDate = new DateTime(2017, 05, 25)
            };
            Student s3 = new Student()
            {
                LastName = "Drax",
                FirstMidName = "Annie",
                EnrollmentDate = new DateTime(2018, 06, 01)
            };
            Add(s1);
            Add(s2);
            Add(s3);
            SaveChanges();
            //ajout des cours
            Course c1 = new Course()
            {
                CourseID = "AEC-420-107",
                Title = "ASP NET Core",
                Credits = 4
            };
            Course c2 = new Course()
            {
                CourseID = "AEC-420-108",
                Title = "PHP",
                Credits = 3
            };
            Course c3 = new Course()
            {
                CourseID = "AEC-420-109",
                Title = "Java EE",
                Credits = 4
            };
            Course c4 = new Course()
            {
                CourseID = "AEC-420-110",
                Title = "Web Services",
                Credits = 2
            };
            Add(c1);
            Add(c2);
            Add(c3);
            Add(c4);
            SaveChanges();
        }

    }
}
