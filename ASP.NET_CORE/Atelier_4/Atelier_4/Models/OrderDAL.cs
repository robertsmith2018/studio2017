using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier_4.Models
{
    public class OrderDAL
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

        public IEnumerable<Order> GetOrdersByCustomer(int customerid)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "SELECT * FROM tbl_orders WHERE CustomerID = @v1";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", customerid));

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Order order = new Order();
                    order.OrderID = rdr.GetInt32(0); // OrderID
                    
                    /* Pour recuperer le customer au complet*/
                    int ID_customer = rdr.GetInt32(1); // customerID
                    order.Customer = new CustomerDAL().GetCustomerByID(ID_customer);
                    /************************************/
                    order.OrderDate = rdr.GetDateTime(2); // OrderDate
                    order.Amount = (double)rdr.GetDecimal(3); // Amount

                    orders.Add(order);
                    
                }
                con.Close();
            }

            return orders;
        }

        public void AddOrder(int customerid, DateTime orderdate, double amount)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "INSERT INTO tbl_orders (CustomerID, OrderDate, Amount)" +
                                 "values (@v1, @v2, @v3)";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", customerid));
                cmd.Parameters.Add(new SqlParameter("@v2", orderdate));
                cmd.Parameters.Add(new SqlParameter("@v3", amount));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateOrder(int orderid, DateTime orderdate, double amount)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "UPDATE tbl_orders SET OrderDate = @v1, Amount = @v2 WHERE OrderID = @v3";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", orderdate));
                cmd.Parameters.Add(new SqlParameter("@v2", amount));
                cmd.Parameters.Add(new SqlParameter("@v3", orderid));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteOrder(int orderid)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "DELETE FROM tbl_orders WHERE OrderID = @v1";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", orderid));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteOrdersBefore(DateTime orderdate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlStmt = "DELETE FROM tbl_orders WHERE OrderDate < @v1";
                SqlCommand cmd = new SqlCommand(sqlStmt, con);
                cmd.Parameters.Add(new SqlParameter("@v1", orderdate));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
