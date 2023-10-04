namespace budda.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        //public string Description { get; set; }
        public int OrderId { get; set; } = 0;
        public Order() { }

    }
}
