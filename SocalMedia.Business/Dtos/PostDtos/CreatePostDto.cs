using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business;

public class CreatePostDto : IDto
{
    public string UserId { get; set; } = null!;
    public string? Text { get; set; } = null!;
    public List<IFormFile> ImageUrls { get; set; } = [];
    public List<IFormFile> VideoUrls { get; set; } = [];
}

