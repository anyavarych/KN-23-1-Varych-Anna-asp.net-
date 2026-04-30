using PasswordGeneratorMvc.Models;

namespace PasswordGeneratorMvc.Data
{
    public static class DatabaseSimulation
    {
        public static List<User> Users { get; set; } = new()
        {
            new User
            {
                Id = "user-1",
                Email = "demo@test.com",
                UserName = "demo"
            }
        };

        public static List<PasswordEntry> PasswordEntries { get; set; } = new()
        {
            new PasswordEntry
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "user-1",
                Title = "Gmail",
                Login = "demo@gmail.com",
                WebsiteUrl = "https://gmail.com/",
                EncryptedPassword = "encrypted_password_example",
                Notes = "Personal mail"
            }
        };

        public static List<PasswordGeneratorSettings> GeneratorSettings { get; set; } = new();
    }
}