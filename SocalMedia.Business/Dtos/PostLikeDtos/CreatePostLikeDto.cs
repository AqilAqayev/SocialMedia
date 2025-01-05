using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostLikeDtos;

public class CreatePostLikeDto : IDto
{
    public int PostId { get; set; }
    public string UserId { get; set; } = null!;
}
