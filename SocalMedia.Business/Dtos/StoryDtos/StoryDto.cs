using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryDtos;

public class StoryDto : IDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
    public bool IsPrivate { get; set; }
    public ICollection<string> StoryVideos { get; set; } = [];
    public ICollection<string> StoryImages { get; set; } = [];
}