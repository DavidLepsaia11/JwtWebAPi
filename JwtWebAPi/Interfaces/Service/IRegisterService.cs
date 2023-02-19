namespace JwtWebAPi.Interfaces.Service
{
    public interface IRegisterService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
