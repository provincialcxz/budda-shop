using System;
using budda.Core.Models;
using budda.DAL;

namespace budda.BLL
{
    public class UserBLL
    {
        private readonly UserDAO _userDAO;

        public UserBLL(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public User GetUserById(int id)
        {
            return _userDAO.GetUserById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userDAO.GetUserByEmail(email);
        }

        public void RegisterUser(User user) // можно добавить проверку пароля
        {
            _userDAO.RegisterUser(user);
        }

        public User LoginUser(string email, string password)
        {
            return _userDAO.LoginUser(email, password);
        }

        public void UpdateProfile(User user)
        {
            _userDAO.UpdateProfile(user);
        }

        public void DeleteUser(int userId)
        {
            _userDAO.DeleteUser(userId);
        }
    }
}