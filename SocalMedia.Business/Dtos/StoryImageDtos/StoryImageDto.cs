using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryImageDtos;

public class StoryImageDto : IDto
{
    public int Id { get; set; }
    public int StoryId { get; set; }
    public string ImageUrl { get; set; } = null!;
}
