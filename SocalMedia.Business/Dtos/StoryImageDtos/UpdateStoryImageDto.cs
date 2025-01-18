using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryImageDtos;

public class UpdateStoryImageDto : IDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
}
