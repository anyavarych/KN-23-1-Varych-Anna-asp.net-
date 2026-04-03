using System.ComponentModel.DataAnnotations;
using PasswordGeneratorMvc.Validators;

namespace PasswordGeneratorMvc.ViewModels
{
    public class PasswordEntryViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Введіть назву")]
        [StringLength(100)]
        public string Title { get; set; } = "";

        public string? Login { get; set; }

        [Url(ErrorMessage = "Невірний URL")]
        public string? WebsiteUrl { get; set; }

        [Required]
        [MinLength(6)]
        [CustomPassword]
        public string Password { get; set; } = "";

        public string? Notes { get; set; }
    }
}