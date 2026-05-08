using Microsoft.AspNetCore.Identity;
namespace PasswordGeneratorMvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
