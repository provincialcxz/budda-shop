using budda.DAL;
using budda.Models;

namespace budda.BLL
{
    public class ProductBLL
    {
        public Product Get(int id)
        {
            var dal = new ProductDAO();
            return dal.Get(id);
        }

        public List<Product> GetProduct()
        {
            var dal = new ProductDAO();
            return dal.GetProduct();
        }

        public void Post(Product product)
        {
            var dal = new ProductDAO();
            dal.Post(product);
        }
        
        public void Put(Product product)
        {
            var dal = new ProductDAO();
            dal.Put(product);
        }

        public void Delete(int id)
        {
            var dal = new ProductDAO();
            dal.Delete(id);
        }
    }
}