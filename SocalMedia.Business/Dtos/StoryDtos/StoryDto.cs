using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.StoryVideoDtos;

namespace SocalMedia.Business.Dtos.StoryDtos;

public class StoryDto : IDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
    public bool IsPrivate { get; set; }
    public ICollection<StoryVideoDto> StoryVideos { get; set; } = new List<StoryVideoDto>();
}
