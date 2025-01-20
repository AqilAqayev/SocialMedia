namespace SocalMedia.Business.Dtos.AdminDtos;

public class UserDto
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public bool? IsDisabled { get; set; }

    public bool IsEmailConfirmed { get; set; }
    public bool IsPrivate { get; set; }
}
