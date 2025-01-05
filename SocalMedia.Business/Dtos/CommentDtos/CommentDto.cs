using SocalMedia.Business.Dtos.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Dtos.CommentDtos;

public class CommentDto : IDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public int PostId { get; set; }
    public string Text { get; set; } = null!; 
    public List<CommentDto> Children { get; set; } = [];
    public DateTime CreatedTime { get; set; }
    public int LikeCount { get; set; }
}

