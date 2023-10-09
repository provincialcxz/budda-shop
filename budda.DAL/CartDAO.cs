using System.Data;
using Dapper;
using budda.Core.Models;
using Microsoft.Data.SqlClient;

namespace budda.DAL
{
    public class UserDAO
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cart;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Cart GetUserCart(int userId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                var cart = db.QueryFirstOrDefault<Cart>("SELECT * FROM UserCarts WHERE UserId = @userId", new { userId });
                if (cart == null)
                {
                    return new Cart();
                }
                return cart;
            }
        }

        public void AddProductToCart(int userId, int productId, int quantity)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("INSERT INTO UserCartItems (UserId, ProductId, Quantity) VALUES (@userId, @productId, @quantity)", 
                            new { userId, productId, quantity });
            }
        }

        public void UpdateUserCart(int userId, Cart cart)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("UPDATE UserCarts SET Product_list = @Product_list, total_price = @total_price, total_quantity = @total_quantity WHERE UserId = @userId",
                            new { userId, cart.Product_list, cart.total_price, cart.total_quantity });
            }
        }

        public void RemoveProductFromCart(int userId, int productId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("DELETE FROM UserCartItems WHERE UserId = @userId AND ProductId = @productId",
                            new { userId, productId });
            }
        }
    }
}