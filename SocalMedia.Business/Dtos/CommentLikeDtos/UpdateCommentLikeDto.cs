using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.CommentLikeDtos;

public class UpdateCommentLikeDto :IDto
{
    public int Id { get; set; }
    public int CommentId { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
}


