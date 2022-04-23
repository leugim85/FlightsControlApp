namespace Domain.Models
{
    public class UserToAdd
    {
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
