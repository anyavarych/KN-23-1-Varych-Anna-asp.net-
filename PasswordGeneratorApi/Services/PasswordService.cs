using PasswordGeneratorApi.Data;
using PasswordGeneratorApi.Models;
namespace PasswordGeneratorApi.Services
{
    public class PasswordService
    {
        public List<PasswordEntry> GetAll()
        {
            return DatabaseSimulation.PasswordEntries;
        }

        public PasswordEntry? GetById(string id)
        {
            return DatabaseSimulation.PasswordEntries.FirstOrDefault(x => x.Id == id);
        }

        public void Create(PasswordEntry entry)
        {
            DatabaseSimulation.PasswordEntries.Add(entry);
        }

        public void Update(string id, PasswordEntry updated)
        {
            var existing = GetById(id);

            if (existing == null)
                return;

            existing.Title = updated.Title;
            existing.Login = updated.Login;
            existing.WebsiteUrl = updated.WebsiteUrl;
            existing.EncryptedPassword = updated.EncryptedPassword;
            existing.Notes = updated.Notes;
            existing.UpdatedAt = DateTime.UtcNow;
        }

        public void Delete(string id)
        {
            var entry = GetById(id);

            if (entry != null)
                DatabaseSimulation.PasswordEntries.Remove(entry);
        } 
    }
}
