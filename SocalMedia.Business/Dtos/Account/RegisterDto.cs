using Microsoft.AspNetCore.Http;
using SocialMedia.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace SocalMedia.Business.Dtos.Account;

public class RegisterDto
{
    public string UserName { get; set; } = null!;
    public string NickName { get; set; } = null!;
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public IFormFile? ProfilePhoto { get; set; }
    public GenderType Gender { get; set; }
}
