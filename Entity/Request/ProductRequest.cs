namespace WebApplication2.Entity.Request
{
    public class ProductRequest
    {
        public string productName { get; set; }
        public int price { get; set; }
        public bool isDeleted { get; set; }
        public int categoryId { get; set; }
        public string description { get; set; }
        public bool isWarranty { get; set; }
    }
}
