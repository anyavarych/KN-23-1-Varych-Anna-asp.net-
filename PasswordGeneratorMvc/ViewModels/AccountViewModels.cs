using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorMvc.ViewModels
{
    
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Вкажіть ім'я")]
        [Display(Name = "Повне ім'я")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть email")]
        [EmailAddress(ErrorMessage = "Невірний формат email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть пароль")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Пароль від 6 до 100 символів")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження пароля")]
        public string ConfirmPassword { get; set; } = "";
    }

   
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Вкажіть email")]
        [EmailAddress(ErrorMessage = "Невірний формат email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = "";

        [Display(Name = "Запам'ятати мене")]
        public bool RememberMe { get; set; }
    }

    
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "Вкажіть ім'я")]
        [Display(Name = "Повне ім'я")]
        public string FullName { get; set; } = "";

        [Display(Name = "Email")]
        public string Email { get; set; } = "";
    }

   
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Вкажіть поточний пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Поточний пароль")]
        public string OldPassword { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть новий пароль")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Пароль від 6 до 100 символів")]
        [DataType(DataType.Password)]
        [Display(Name = "Новий пароль")]
        public string NewPassword { get; set; } = "";

        [Required(ErrorMessage = "Підтвердіть новий пароль")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження нового пароля")]
        public string ConfirmNewPassword { get; set; } = "";
    }

   
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Вкажіть email")]
        [EmailAddress(ErrorMessage = "Невірний формат email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";
    }

    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Вкажіть новий пароль")]
        [StringLength(100, MinimumLength = 6,
            ErrorMessage = "Пароль від 6 до 100 символів")]
        [DataType(DataType.Password)]
        [Display(Name = "Новий пароль")]
        public string NewPassword { get; set; } = "";

        [Required(ErrorMessage = "Підтвердіть пароль")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження пароля")]
        public string ConfirmPassword { get; set; } = "";
    }
    public class UserListItemViewModel
    {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        public string FullName { get; set; } = "";
        public IList<string> Roles { get; set; } = new List<string>();
        public bool IsLockedOut { get; set; }
    }

    public class EditUserRolesViewModel
    {
        public string UserId { get; set; } = "";
        public string Email { get; set; } = "";
        public string FullName { get; set; } = "";
        public List<RoleCheckbox> Roles { get; set; } = new();
    }

    public class RoleCheckbox
    {
        public string RoleName { get; set; } = "";
        public bool IsSelected { get; set; }
    }
}