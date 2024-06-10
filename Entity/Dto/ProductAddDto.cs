namespace WebApplication2.Entity.Dto
{
    public class ProductAddDto
    {

        public string productName { get; set; }
        public int price { get; set; }
        public int categoryId { get; set; }
        public string Description { get; set; }
        public bool isWarranty { get; set; }
    }
}
