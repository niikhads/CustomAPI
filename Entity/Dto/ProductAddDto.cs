namespace WebApplication2.Entity.Dto
{
    public class ProductAddDto
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public int category_id { get; set; }
        public string Description { get; set; }
        public bool Warranty { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }
}
