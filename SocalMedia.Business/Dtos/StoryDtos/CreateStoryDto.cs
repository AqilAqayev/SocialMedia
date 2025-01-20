using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.StoryDtos;

public class CreateStoryDto :IDto
{
    public bool IsPrivate { get; set; }
    public List<IFormFile> VideoUrls { get; set; } = [];
    public List<IFormFile> ImagesUrls { get; set; } = [];
}
