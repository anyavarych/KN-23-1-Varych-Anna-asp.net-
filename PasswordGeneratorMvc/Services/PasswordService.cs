using PasswordGeneratorMvc.Models;
using PasswordGeneratorMvc.Data;

namespace PasswordGeneratorMvc.Services
{
    public class PasswordService
    {
        public List<PasswordEntry> GetAll()
            => DatabaseSimulation.PasswordEntries;

        public PasswordEntry GeneratePassword(string title, string login)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();

            var password = new string(Enumerable.Range(0, 16)
                .Select(x => chars[random.Next(chars.Length)]).ToArray());

            var entry = new PasswordEntry
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "user-1",
                Title = title,
                Login = login,
                EncryptedPassword = password,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            DatabaseSimulation.PasswordEntries.Add(entry);

            return entry;
        }

        public PasswordEntry GetById(string id)
        {
            return DatabaseSimulation.PasswordEntries.First(x => x.Id == id);
        }

        public void Create(PasswordEntry entry)
        {
            entry.Id = Guid.NewGuid().ToString();
            entry.CreatedAt = DateTime.UtcNow;
            entry.UpdatedAt = DateTime.UtcNow;

            DatabaseSimulation.PasswordEntries.Add(entry);
        }

        public void Update(PasswordEntry entry)
        {
            var existing = GetById(entry.Id);

            existing.Title = entry.Title;
            existing.Login = entry.Login;
            existing.WebsiteUrl = entry.WebsiteUrl;
            existing.EncryptedPassword = entry.EncryptedPassword;
            existing.Notes = entry.Notes;
            existing.UpdatedAt = DateTime.UtcNow;
        }

        public void Delete(string id)
        {
            var item = DatabaseSimulation.PasswordEntries.FirstOrDefault(x => x.Id == id);

            if (item != null)
                DatabaseSimulation.PasswordEntries.Remove(item);
        }
    }
}