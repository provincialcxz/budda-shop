using budda.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

public class OrderDAO
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Orders;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public List<Order> GetUserOrders(string userId)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Order>("SELECT * FROM Orders WHERE UserId = @userId", new { userId }).ToList();
        }
    }

    public Order GetOrder(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Order>("SELECT * FROM Orders WHERE Id = @id", new { id }).FirstOrDefault();
        }
    }

    public void CreateOrder(Order order)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = "INSERT INTO Orders (UserId, ProductId, OrderDate, Status) VALUES (@UserId, @ProductId, @OrderDate, @Status); SELECT CAST(SCOPE_IDENTITY() as int)";
            order.Id = db.Query<int>(sqlQuery, order).FirstOrDefault();
        }
    }

    public void UpdateOrder(int id, string newStatus)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = "UPDATE Orders SET Status = @newStatus WHERE Id = @id";
            db.Execute(sqlQuery, new { id, newStatus });
        }
    }
}