using budda.DAL;
using budda.Models;

namespace budda.BLL
{
    public class BLL
    {
        public void product(Product product)
        {
            var dal = new DALLayer();
            dal.GetConection(product).GetAwaiter().GetResult();
        }
    }
}