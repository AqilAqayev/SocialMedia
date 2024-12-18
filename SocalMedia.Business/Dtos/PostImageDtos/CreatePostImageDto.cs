using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostImageDtos;

public class CreatePostImageDto : IDto
{
    public int PostId { get; set; }
    public IFormFile ImageUrl { get; set; } = null!;
}
