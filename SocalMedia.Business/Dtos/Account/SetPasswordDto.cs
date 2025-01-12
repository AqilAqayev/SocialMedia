using System.ComponentModel.DataAnnotations;

namespace SocalMedia.Business.Dtos.Account;

public class SetPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [Required]
    [Compare("NewPassword")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}