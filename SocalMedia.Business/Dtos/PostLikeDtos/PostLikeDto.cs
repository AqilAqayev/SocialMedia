using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostLikeDtos;

public class PostLikeDto : IDto
{
    public int PostId { get; set; }
    public string UserId { get; set; } = null!;
}
