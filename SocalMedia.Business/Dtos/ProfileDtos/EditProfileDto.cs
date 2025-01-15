using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.ProfileDtos;

public class EditProfileDto : IDto
{
    public string? UserName { get; set; }
    public string? Bio { get; set; }
    public string? PhoneNumber { get; set; }
    public IFormFile? ProfilePhoto { get; set; }
    public bool IsPrivate { get; set; } 

}

