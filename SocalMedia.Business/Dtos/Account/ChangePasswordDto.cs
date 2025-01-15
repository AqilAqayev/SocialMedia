using System.ComponentModel.DataAnnotations;

namespace SocalMedia.Business.Dtos.Account;

public class ChangePasswordDto
{
    public string? OldPassword { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Required]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmNewPassword { get; set; } = null!;
}
