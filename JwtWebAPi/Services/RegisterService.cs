using JwtWebAPi.Interfaces.Service;
using System.Security.Cryptography;

namespace JwtWebAPi.Services
{
    public class RegisterService : IRegisterService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
