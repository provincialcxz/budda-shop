using System.Data;
using Dapper;
using budda.Core.Models;
using Microsoft.Data.SqlClient;

namespace budda.DAL
{
    public class UserDAO
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User GetUserById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Email = @email", new { email }).FirstOrDefault();
            }
        }

        public void RegisterUser(User user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                db.Execute(sqlQuery, user);
            }
        }

        public User LoginUser(string email, string password)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Email = @email AND Password = @password", new { email, password }).FirstOrDefault();
            }
        }

        public void UpdateProfile(User user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("UPDATE Users SET Name = @Name, Email = @Email, Password = @Password WHERE Id = @Id", user);
            }
        }

        public void DeleteUser(int userId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("DELETE FROM Users WHERE Id = @userId", new { userId });
            }
        }
    }
}