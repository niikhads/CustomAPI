namespace WebApplication2.Entity.Response
{
    public class ImageResponse
    {
        public int id { get; set; }
        public byte[] Data { get; set; }
        public int product_id { get; set; }
        public bool is_Deleted { get; set; }
    }
}
