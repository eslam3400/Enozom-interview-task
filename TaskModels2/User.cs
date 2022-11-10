using TaskModels.Enums;

namespace TaskModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; }
    }
}
