using System.Security.Cryptography.X509Certificates;

namespace WebApplication2.Entity.Model
{
    public class Product
    {

        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool is_Deleted { get; set; }
        public int category_id { get; set; }
        public string Description { get; set; }
        public bool Warranty { get; set; }
        public List<Image> Images { get; set; }
        
        public virtual Category Category { get; set; }  

    }
}
