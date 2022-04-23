using Domain.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPasswordHash(UserResultDto user, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}
