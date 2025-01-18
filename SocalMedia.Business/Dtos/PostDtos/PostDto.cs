using SocalMedia.Business.Dtos;
using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business;

public class PostDto : IDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
    public bool IsDelete { get; set; }
    public List<string> ImageUrls { get; set; } = new List<string>();
    public List<string>? VideoUrls { get; set; } = [];
    public List<CommentDto> Comments { get; set; } = [];
    public List<ChatDto> ChatDtos { get; set; } = [];
    public int Count { get; set; }
    public int PostCount { get; set; }
    public int CommentCount { get; set;}
    public string? ProfilePhotoUrl { get; set; }
}

