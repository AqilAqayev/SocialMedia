using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryDtos;

public class UpdateStoryDto :IDto
{
    public string UserId { get; set; } = null!;
    public bool IsPrivate { get; set; }
}
