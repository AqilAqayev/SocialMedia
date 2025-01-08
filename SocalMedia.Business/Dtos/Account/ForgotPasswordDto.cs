using System.ComponentModel.DataAnnotations;

namespace SocalMedia.Business.Dtos.Account;

public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}