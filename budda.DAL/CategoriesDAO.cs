using budda.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace budda.DAL
{
    public class CategoriesDAO
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Categories;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Category> GetCategory()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Category>("SELECT * FROM Categories").ToList();
            }
        }

        public void Post(Category category)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Categories (Name, Id, productsId) VALUES (@Name, @Id, @productsId)";
                db.Execute(sqlQuery, category);
            }
        }

        public void Put(Category category)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = ("UPDATE Categories SET Name = @Name, Id = @Id, productsId = @productsId WHERE Id = @Id");
                db.Execute(sqlQuery, category);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = ("DELETE FROM Categories WHERE Id = @Id");
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
