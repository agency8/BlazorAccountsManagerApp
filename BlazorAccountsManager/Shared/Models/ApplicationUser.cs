using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAccountsManager.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(128)")]
        public string FirstName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(128)")]
        public string LastName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(128)")]
        public string DisplayName { get; set; } = string.Empty;
        public string CustomClaim { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
