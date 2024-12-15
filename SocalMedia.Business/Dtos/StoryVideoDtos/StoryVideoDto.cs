using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryVideoDtos;

public class StoryVideoDto :IDto
{
    public int Id { get; set; }
    public int StoryId { get; set; }
    public string VideoUrl { get; set; } = null!;
}
