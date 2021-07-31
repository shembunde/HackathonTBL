using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise08
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source =DESKTOP-7K60JLI\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security = True";

            string query = "Select CompanyName " + Environment.NewLine +
                    "from Customers " + Environment.NewLine;

            Console.WriteLine("Enter City Name:");
            int city = Convert.ToInt32(Console.ReadLine());
            Console.Clear();


            using (SqlConnection sqlcon1 = new SqlConnection(connectionString))
            {
                sqlcon1.Open();
                using (SqlCommand sql1 = new SqlCommand(query, (sqlcon1)))
                {
                    sql1.Parameters.AddWithValue("@city", city);
                    using (SqlDataReader reader = sql1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.Write("Company names: {0}\nCompany Name \n\n", reader[0]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("no results");
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}