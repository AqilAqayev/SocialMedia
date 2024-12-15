using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.CommentLikeDtos;

public class CreateCommentLikeDto : IDto
{
    public int CommentId { get; set; }
    public string UserId { get; set; } = null!;
}


