using Microsoft.AspNetCore.Http;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostImageDtos;

public class PostImageDto :IDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
}
