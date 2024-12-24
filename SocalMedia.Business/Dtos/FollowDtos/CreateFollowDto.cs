using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.FollowDtos;

public class CreateFollowDto : IDto
{
    public string FollowerId { get; set; } = null!;
    public string FollowingId { get; set; } = null!;
    public string Status { get; set; } = null!;
}
