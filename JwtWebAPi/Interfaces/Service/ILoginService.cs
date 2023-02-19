﻿

namespace JwtWebAPi.Interfaces.Service
{
    public interface ILoginService
    {
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}