namespace SocalMedia.Business.Dtos.AdminDtos;

public class UpdateUserStatusDto
{
    public string UserId { get; set; } = null!;
    public bool IsDisabled { get; set; }
}