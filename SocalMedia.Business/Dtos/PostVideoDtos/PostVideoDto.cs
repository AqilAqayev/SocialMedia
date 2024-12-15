using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostVideoDtos;

public class PostVideoDto : IDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string VideoUrl { get; set; } = null!;
}
