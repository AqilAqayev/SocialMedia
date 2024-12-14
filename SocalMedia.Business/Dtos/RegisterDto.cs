using SocialMedia.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocalMedia.Business.Dtos;

public class RegisterDto
{
    public string NickName { get; set; } = null!;
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public GenderType Gender { get; set; }  
}
