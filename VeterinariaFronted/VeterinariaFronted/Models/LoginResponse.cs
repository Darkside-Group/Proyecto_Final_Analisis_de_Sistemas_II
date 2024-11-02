namespace VentaFronted.Models
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
