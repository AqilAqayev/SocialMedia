using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryDtos;

public class UserStoriesDto : IDto
{
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!; 
    public string ProfilePhotoUrl { get; set; } = null!;
    public List<StoryDto> Stories { get; set; } = new();
}
