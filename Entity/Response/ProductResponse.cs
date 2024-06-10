namespace WebApplication2.Entity.Response
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public bool isDeleted { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool isWarranty { get; set; }
    }
}
