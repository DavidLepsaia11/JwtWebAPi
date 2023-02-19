using JwtWebAPi.Interfaces.Service;
using System.Security.Cryptography;

namespace JwtWebAPi.Services
{
    public class LoginService : ILoginService
    {
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
