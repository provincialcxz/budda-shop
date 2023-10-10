using budda.Models;

namespace budda.Core.Models
{
    public class Cart
    {
        public int ProductId { get; set; }
        public int total_price { get; set; }
        public int total_quantity { get; set;}
    }
}
