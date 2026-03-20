using System;
using System.Linq;
using System.Collections.Generic;
using PasswordGeneratorMvc.Models;
using PasswordGeneratorMvc.Data;

namespace PasswordGeneratorMvc.Services;

public class PasswordService
{
    public List<PasswordEntry> GetAll() => DatabaseSimulation.PasswordEntries;

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

    public void Delete(string id)
    {
        var item = DatabaseSimulation.PasswordEntries.FirstOrDefault(x => x.Id == id);
        if (item != null)
            DatabaseSimulation.PasswordEntries.Remove(item);
    }
}