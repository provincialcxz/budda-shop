using System.Data;
using Dapper;
using budda.Core.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace budda.DAL
{
    public class UserDAO
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM User WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Email = @email", new { email }).FirstOrDefault();
            }
        }

        public void Post(User user)
            {
            //using (IDbConnection db = new SqlConnection(connectionString))
            //{
            //    var sqlQuery = "INSERT INTO User (Id, Name, mail, Password) VALUES (@Id, @Name, @mail, @Password)";
            //    db.Execute(sqlQuery, user);
            //}
        }

        public void Put(User user)
        {
            //using (IDbConnection db = new SqlConnection(connectionString))
            //{
            //    var sqlQuery = ("UPDATE User SET Name = @Name, mail = @mail, Password = @Password WHERE Id = @Id");
            //    db.Execute(sqlQuery, user);
            //}
            }
        }

        public void Delete(int id)
        {
            //using (IDbConnection db = new SqlConnection(connectionString))
            //{
            //    var sqlQuery = ("DELETE FROM User WHERE Id = @Id");
            //    db.Execute(sqlQuery, new { id });
            //}
        }
    }
}