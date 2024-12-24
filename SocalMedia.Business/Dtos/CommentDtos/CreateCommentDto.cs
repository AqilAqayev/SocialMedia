using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.CommentDtos;

public class CreateCommentDto : IDto
{
    public string Text { get; set; } = null!;   
    public int Rating { get; set; }
    public int PostId { get; set; }
}

public class CommentReplyDto : IDto
{
    public int ParentId { get; set; }
    public int PostId { get; set; }

    public string Text { get; set; }
}
