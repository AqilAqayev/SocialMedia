using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.ProfileDtos;

public class FriendClosed : IDto
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public string? ProfileImage { get; set; }
}


