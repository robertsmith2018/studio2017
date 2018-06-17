using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStudentADO.Models
{
    public class StudentDAL
    {
        public static IConfiguration Configuration { get; set; }

        //To Read ConnectionString from appsettings.json file  
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            return connectionString;
        }

        string connectionString = GetConnectionString();

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "SELECT * FROM tbl_students";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();
                    student.Id = rdr.GetInt32(0); //id
                    student.FirstName = rdr.GetString(1); //firstname
                    student.LastName = rdr.GetString(2); //lastname
                    student.NoteFinale = (double)rdr.GetDecimal(3); // note finel

                    students.Add(student);
                }
                con.Close();
            }
            return students;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "INSERT INTO tbl_students (firstname, lastname, notefinale)" +
                                 "values (@v1, @v2, @v3)";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", student.FirstName));
                cmd.Parameters.Add(new SqlParameter("@v2", student.LastName));
                cmd.Parameters.Add(new SqlParameter("@v3", student.NoteFinale));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
