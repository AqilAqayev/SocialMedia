using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocalMedia.Business.Dtos.StoryDtos;

public class CreateStoryDto :IDto
{
    [Required]
    public string UserId { get; set; } = null!;
    public bool IsPrivate { get; set; }
    public List<IFormFile> VideoUrls { get; set; } = [];
    public List<IFormFile> ImagesUrls { get; set; } = [];

}
