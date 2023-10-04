namespace budda.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int[] productsId { get; set; }
        public Category() { }
        public Category(string name, int id) { }

    }
}
