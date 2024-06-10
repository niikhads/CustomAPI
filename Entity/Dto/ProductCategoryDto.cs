namespace WebApplication2.Entity.Dto
{
    public class ProductCategoryDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

       // public bool isDeleted { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }

         public bool isWarranty { get; set; }
        public string CategoryName { get; set; }
    }
}
