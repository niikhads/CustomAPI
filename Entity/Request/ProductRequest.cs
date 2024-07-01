namespace WebApplication2.Entity.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool is_Deleted { get; set; }
        public int category_id { get; set; }
        public string Description { get; set; }
        public bool Warranty { get; set; }
    }
}
