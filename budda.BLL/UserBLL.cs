using System;
using budda.Core.Models;
using budda.DAL;

namespace budda.BLL
{
    public class UserBLL
    {
        public User Get(int id)
        {
            var dal = new UserDAO();
            return dal.Get(id);
        }

        public void Post(User user)
        {
            var dal = new UserDAO();
            dal.Post(user);
        }

        public void Put(User user)
        {
            var dal = new UserDAO();
            dal.Put(user);
        }

        public void Delete(int id)
        {
            var dal = new UserDAO();
            dal.Delete(id);
        }
    }
}