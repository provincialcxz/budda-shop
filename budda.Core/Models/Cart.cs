using budda.Models;

namespace budda.Core.Models
{
    public class Cart
    {
        public List<Product> Product_list { get; set; }
        public int total_price { get; set; }
        public int total_quantity { get; set;}
    }
}