using Azure;
using budda.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace budda.DAL
{
    public class DALLayer
    {
        public async Task GetConection(Product product)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //int Id = 10;
            //string ProductName = "Bup";
            //int Price = 100;
            //string Description = "Bupi Bupi Bup";

            string sqlExpression = "INSERT INTO Product (Id, ProductName, Price, Description) VALUES (@Id, @ProductName, @Price, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                // создаем параметры
                SqlParameter IdParam = new SqlParameter("@Id", product.Id);
                command.Parameters.Add(IdParam);

                SqlParameter ProductNameParam = new SqlParameter("@ProductName", product.ProductName);
                command.Parameters.Add(ProductNameParam);

                SqlParameter PriceParam = new SqlParameter("@Price", product.Price);
                command.Parameters.Add(PriceParam);

                SqlParameter DescriptionParam = new SqlParameter("@Description", product.Description);
                command.Parameters.Add(DescriptionParam);

                try
                {
                    int number = await command.ExecuteNonQueryAsync();

                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}