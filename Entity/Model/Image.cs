namespace WebApplication2.Entity.Model
{
    public class Image
    {
        public int ImageId { get; set; }     
        public byte Data {  get; set; }
        public int ProductId {  get; set; }
        public bool isDeleted { get; set; }
    }
}
