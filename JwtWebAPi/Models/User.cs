namespace JwtWebAPi.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
