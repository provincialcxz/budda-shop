using budda.Core.Models;
using budda.DAL;

namespace budda.BLL
{
    public class UserBLL
    {
        public List<Cart> GetCart()
        {
            var dal = new CartDAO();
            return dal.GetCart();
        }

        public void Post(Cart cart)
        {
            var dal = new CartDAO();
            dal.Post(cart);
        }

        public void Put(Cart cart)
        {
            var dal = new CartDAO();
            dal.Put(cart);
        }

        public void Delete(int id)
        {
            var dal = new CartDAO();
            dal.Delete(id);
        }
    }
}