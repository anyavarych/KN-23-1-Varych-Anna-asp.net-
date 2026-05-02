using PasswordGeneratorMvc.Data;
using PasswordGeneratorMvc.Models;

namespace PasswordGeneratorMvc.Services
{
    public class PasswordService
    {
        public List<PasswordEntry> GetAll()
            => DatabaseSimulation.PasswordEntries;

        public PasswordEntry? GetById(string id)
            => DatabaseSimulation.PasswordEntries.FirstOrDefault(x => x.Id == id);

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
            if (existing == null) return;

            existing.Title = entry.Title;
            existing.Login = entry.Login;
            existing.WebsiteUrl = entry.WebsiteUrl;
            existing.EncryptedPassword = entry.EncryptedPassword;
            existing.UpdatedAt = DateTime.UtcNow;
        }

        public void Delete(string id)
        {
            var item = GetById(id);
            if (item != null)
                DatabaseSimulation.PasswordEntries.Remove(item);
        }
    }
}