using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostDtos;

public class UpdatePostDto : IDto
{
    public string PostId { get; set; } = null!;
    public string? Text { get; set; }
    public ICollection<string>? ImageUrls { get; set; } = [];
    public ICollection<string>? VideoUrls { get; set; } = [];
}

