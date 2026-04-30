using System.ComponentModel.DataAnnotations;
using PasswordGeneratorMvc.Validators;

namespace PasswordGeneratorMvc.ViewModels
{
    public class PasswordEntryViewModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Введіть назву")]
        public string Title { get; set; } = "";

        public string? Login { get; set; }

        [Url(ErrorMessage = "Невірний URL")]
        public string? WebsiteUrl { get; set; }

        [Required(ErrorMessage = "Пароль обов'язковий")]
        [MinLength(6, ErrorMessage = "Мінімум 6 символів")]
        [CustomPassword]
        public string Password { get; set; } = "";

        public string? Notes { get; set; }
    }
}