using DataBase;
using Domain.Models;
using System;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthService authService;
        private readonly IDatabaseConnection connection;

        public UserService(IAuthService authService, IDatabaseConnection connection)
        {
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public UserToAdd Register(UserDto userDto)
        {
            var exists = connection.ValidateIfExists(userDto.UserName, "UserName", "Users");
            if (exists) 
            {
                return null;
            }
            authService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            UserToAdd user = new UserToAdd();
            user.UserName = userDto.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            connection.AddUser(user);
            return user;
        }

        public UserInValidationDto Login(UserDto userDto)
        {
            var userOnValidation = new UserInValidationDto();

            var user = connection.ValidateUser(userDto.UserName);
            if (user.UserName is null)
            {
                return null;
            }
            if (!authService.VerifyPasswordHash(user, userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            userOnValidation.UserName = user.UserName;
            userOnValidation.PasswordHash = user.PasswordHash;

            return userOnValidation;
        }
    }
}
