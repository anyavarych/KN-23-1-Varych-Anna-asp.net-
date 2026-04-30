namespace PasswordGeneratorApi.Models
{
    public class PasswordEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = "";

        public string Title { get; set; } = "";

        public string? Login { get; set; }

        public string? WebsiteUrl { get; set; }

        public string EncryptedPassword { get; set; } = "";

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
