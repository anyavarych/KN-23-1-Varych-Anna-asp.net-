using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorMvc.Validators
{
    public class CustomPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password))
                return ValidationResult.Success;

            if (!password.Any(char.IsDigit))
                return new ValidationResult("Пароль повинен містити хоча б 1 цифру");

            return ValidationResult.Success;
        }
    }
}