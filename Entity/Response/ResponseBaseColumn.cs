namespace WebApplication2.Entity.Response
{
    public class ResponseBaseColumn
    {
        public string Status {  get; set; } 

        public object? Data {  get; set; }
        public bool IsSuccess {  get; set; }
        public string Message {  get; set; }
    }
}
