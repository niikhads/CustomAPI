namespace WebApplication2.Entity.Model
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string is_deleted { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
