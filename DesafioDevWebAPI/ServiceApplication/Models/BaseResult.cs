namespace ServiceApplication.Models
{
    public class BaseResult
    {
        public string Message { get; set; }

        public object Result { get; set; }

        public bool Error { get; set; }
    }
}
