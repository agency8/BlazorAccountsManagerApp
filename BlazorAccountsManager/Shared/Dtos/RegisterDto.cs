using System.ComponentModel.DataAnnotations;

namespace BlazorAccountsManager.Shared.Dtos
{
	public class RegisterDto
	{
		[Required]
		[StringLength(128, ErrorMessage = "FirstName is required")]
		[Display(Name = "FirstName")]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[StringLength(128, ErrorMessage = "SurName is required")]
		[Display(Name = "Surname")]
		public string LastName { get; set; } = string.Empty;

		public string DisplayName { get; set; } = string.Empty;


		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; } = string.Empty;

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}
