namespace WebApplication2.Entity.Response
{
    public class ResponseBaseColumn
    {
        public string Status {  get; set; } 

        public dynamic? Data {  get; set; }
        public bool IsSuccess {  get; set; }
        public string Message {  get; set; }
    }
}
