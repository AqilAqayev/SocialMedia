using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.CommentDtos;

public class UpdateCommentDto : IDto
{
    public int CommentId { get; set; }
    public string? Text { get; set; }
}

