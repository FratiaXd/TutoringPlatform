using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringPlatform.Shared.InputModels
{
    public class PasswordInput
    {
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; } = "";

        [DataType(DataType.Password)]
        [Display(Name = "Admin password")]
        public string AdminPassword { get; set; } = "";

        [Required]
        [StringLength(100, ErrorMessage = "Password must contain at least one special character, one lowercase, one uppercase, and one digit. MinimumLength = 6", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; } = "";

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
