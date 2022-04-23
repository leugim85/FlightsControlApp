using Domain.Models;

namespace Business.Services
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(UserResultDto user, string password, byte[] passwordHash, byte[] passwordSalt);
    }
}