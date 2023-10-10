using budda.Core.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace budda.DAL
{
    public class CartDAO
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cart;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Cart> GetCart()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Cart>("SELECT * FROM Cart").ToList();
            }
        }

        public void Post(Cart cart)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Cart (Product_list, total_price, total_quantity) VALUES (@Product_list, @total_price, @total_quantity)";
                db.Execute(sqlQuery, cart);
            }
        }

        public void Put(Cart cart)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = ("UPDATE Cart SET total_price = @total_price, total_quantity = @total_quantity WHERE ProductId = @ProductId");
                db.Execute(sqlQuery, cart);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = ("DELETE FROM Cart WHERE ProductId = @ProductId");
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
