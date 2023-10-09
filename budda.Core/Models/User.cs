namespace budda.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string mail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } = string.Empty;
        
    }
}