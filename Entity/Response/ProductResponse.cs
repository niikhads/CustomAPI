namespace WebApplication2.Entity.Response
{
    public class ProductResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool is_Deleted { get; set; }
        public int category_id { get; set; }
        public string Description { get; set; }
        public bool is_Warranty { get; set; }
    }
}
