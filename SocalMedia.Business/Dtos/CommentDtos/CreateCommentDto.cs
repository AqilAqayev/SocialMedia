using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.CommentDtos;

public class CreateCommentDto : IDto
{
    public string UserId { get; set; } = null!;
    public int PostId { get; set; }
    public string Text { get; set; } = null!;
}

