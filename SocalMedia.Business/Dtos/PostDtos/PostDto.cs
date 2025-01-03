using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Dtos.PostVideoDtos;

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
    public List<string> Comments { get; set; } = [];
    public List<ChatDto> ChatDtos { get; set; } = [];
}

