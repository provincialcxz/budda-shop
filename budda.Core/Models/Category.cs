namespace budda.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<int> productsId { get; set; }

    }
}
