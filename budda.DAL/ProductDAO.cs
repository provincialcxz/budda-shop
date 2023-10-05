using Azure;
using budda.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace budda.DAL
{
    public class ProductDAO
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Products;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public List<Product> GetProduct()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Product>("SELECT * FROM Product").ToList();
            }
        }
        
        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Product>("SELECT * FROM Product WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
        
        public void Post(Product product)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Product (Id, ProductName, Price, Description) VALUES (@Id, @ProductName, @Price, @Description)";
                db.Execute(sqlQuery, product);

                /*
                // если мы хотим получить айди добавленного продукта
                var sqlQuery = "INSERT INTO Product (Id, ProductName, Price, Description) VALUES (@Id, @ProductName, @Price, @Description); SELECT CAST(SCOPE_IDENTIFY() as int)";
                int? productId = db.Query<int>(sqlQuery, product).FirstOrDefault();
                product.Id = productId.Value;
                */
            }
        }

        public void Put(Product product) 
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = ("UPDATE Product SET ProductName = @ProductName, Price = @Price, Description = @Description WHERE Id = @Id");
                db.Execute(sqlQuery, product);
            }
        }

        public void Delete(int id) 
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = ("DELETE FROM Product WHERE Id = @Id");
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}

// это работало!!!
//public async Task GetConection(Product product)
//{

//    //int Id = 10;
//    //string ProductName = "Bup";
//    //int Price = 100;
//    //string Description = "Bupi Bupi Bup";

//    string sqlExpression = "INSERT INTO Product (Id, ProductName, Price, Description) VALUES (@Id, @ProductName, @Price, @Description)";



//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        await connection.OpenAsync();

//        SqlCommand command = new SqlCommand(sqlExpression, connection);

//        // создаем параметры
//        SqlParameter IdParam = new SqlParameter("@Id", product.Id);
//        command.Parameters.Add(IdParam);

//        SqlParameter ProductNameParam = new SqlParameter("@ProductName", product.ProductName);
//        command.Parameters.Add(ProductNameParam);

//        SqlParameter PriceParam = new SqlParameter("@Price", product.Price);
//        command.Parameters.Add(PriceParam);

//        SqlParameter DescriptionParam = new SqlParameter("@Description", product.Description);
//        command.Parameters.Add(DescriptionParam);

//        try
//        {
//            int number = await command.ExecuteNonQueryAsync();

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.ToString());
//        }
//    }
//}