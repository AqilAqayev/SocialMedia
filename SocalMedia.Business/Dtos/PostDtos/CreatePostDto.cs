using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business;

public class CreatePostDto : IDto
{
    public string UserId { get; set; } = null!;
    public string Text { get; set; } = null!;
    public ICollection<string> ImageUrls { get; set; } = [];
    public ICollection<string> VideoUrls { get; set; } = [];
}

