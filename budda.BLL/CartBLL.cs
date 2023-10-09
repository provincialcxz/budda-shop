using budda.Core.Models;
using budda.DAL;

namespace budda.BLL
{
    public class UserBLL
    {
        private readonly UserDAO userDAO;

        public UserBLL(UserDAO user_DAO)
        {
            _userDAO = user_DAO;
        }

        public Cart GetUserCart(int userId)
        {
            return _userDAO.GetUserCart(userId);
        }

        public void AddProductToCart(int userId, int productId, int quantity)
        {
            _userDAO.AddProductToCart(userId, productId, quantity);
        }

        public void UpdateUserCart(int userId, Cart cart)
        {
            _userDAO.UpdateUserCart(userId, cart);
        }

        public void RemoveProductFromCart(int userId, int productId)
        {
            _userDAO.RemoveProductFromCart(userId, productId);
        }
    }
}