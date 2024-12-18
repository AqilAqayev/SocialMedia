using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostImageDtos;

public class UpdatePostImageDto : IDto
{
    public IFormFile ImageUrl { get; set; } = null!;
}
