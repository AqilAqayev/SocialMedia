using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostVideoDtos;

public class CreatePostVideoDto : IDto
{
    public int PostId { get; set; }
    public string VideoUrl { get; set; } = null!;
}
