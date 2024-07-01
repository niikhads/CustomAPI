namespace WebApplication2.Entity.Dto
{
    public class ProductCategoryDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        // public bool isDeleted { get; set; }
        public int category_id { get; set; }
        public string Description { get; set; }

        public bool Warranty { get; set; }
        public string category_name { get; set; }
    }
}
