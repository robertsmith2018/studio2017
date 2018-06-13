using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_4.Models
{
    public class CustomerDAL
    {
        /* Block pour établir une connexion avec le server SQL*/
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

        //***************************************//
        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "SELECT * FROM tbl_customers";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = rdr.GetInt32(0); //id
                    customer.CustomerName = rdr.GetString(1); //full name
                    customer.Country = rdr.GetString(2); //counrty
                    customer.CreationDate = rdr.GetDateTime(3); // creation date

                    customers.Add(customer);
                }
                con.Close();
            }
            return customers;
        }

        public Customer GetCustomerByID(int customerID)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "SELECT * FROM tbl_customers WHERE CustomerID = @v1";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", customerID));

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customer.CustomerID = rdr.GetInt32(0); //id
                    customer.CustomerName = rdr.GetString(1); //full name
                    customer.Country = rdr.GetString(2); //counrty
                    customer.CreationDate = rdr.GetDateTime(3); // creation date
                }
                con.Close();
            }
            return customer;
        }


        public void AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "INSERT INTO tbl_customers (CustomerName, Country, CreationDate)" +
                                 "values (@v1, @v2, @v3)";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", customer.CustomerName));
                cmd.Parameters.Add(new SqlParameter("@v2", customer.Country));
                cmd.Parameters.Add(new SqlParameter("@v3", customer.CreationDate));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<Customer> GetNewCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "SELECT * FROM tbl_customers WHERE CreationDate > @v1";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);

                int currentDay = DateTime.Now.Day;
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;
                cmd.Parameters.Add(new SqlParameter("@v1", new DateTime(currentYear-1,currentMonth,currentDay)));

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = rdr.GetInt32(0); //id
                    customer.CustomerName = rdr.GetString(1); //full name
                    customer.Country = rdr.GetString(2); //counrty
                    customer.CreationDate = rdr.GetDateTime(3); // creation date

                    customers.Add(customer);
                }
                con.Close();
            }
            return customers;
        }

    }
}
