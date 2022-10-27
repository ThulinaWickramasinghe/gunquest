namespace RPG.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Messege { get; set; } = string.Empty;
    }
}