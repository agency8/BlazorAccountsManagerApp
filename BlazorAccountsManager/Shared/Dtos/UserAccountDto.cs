using System.ComponentModel.DataAnnotations;

namespace BlazorAccountsManager.Shared.Dtos
{
    public class UserAccountDto
    {
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Username must be larger than 7 charactors!")]
        [Display(Name = "UserName")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(256, ErrorMessage = "A valid is required")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(128, ErrorMessage = "FirstName is required")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(128, ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        public string LastName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string UserRole { get; set; } = "Registered";
        public bool IsSuperUser { get; set; } = false;
    }
}
