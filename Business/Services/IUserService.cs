using Domain.Models;

namespace Business.Services
{
    public interface IUserService
    {
        UserToAdd Register(UserDto userDto);

        public UserInValidationDto Login(UserDto userDto);
    }
}