using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostVideoDtos;

public class UpdatePostVideoDto : IDto
{
    public int PostId { get; set; }
    public string VideoUrl { get; set; } = null!;
}
