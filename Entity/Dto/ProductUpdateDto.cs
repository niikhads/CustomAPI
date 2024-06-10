namespace WebApplication2.Entity.Dto
{
    public class ProductUpdateDto
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int PategoryId { get; set; }
        public string Description { get; set; }
        public bool isWarranty { get; set; }
    }
}
