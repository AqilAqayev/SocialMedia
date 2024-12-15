using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business;

public class PostDto : IDto
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Text { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
    public bool IsDelete { get; set; }
    public ICollection<string> ImageUrls { get; set; } = [];
    public ICollection<string> VideoUrls { get; set; } = [];
    public ICollection<string> Comments { get; set; } = [];
}

