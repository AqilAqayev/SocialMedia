using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostImageDtos;

public class CreatePostImageDto : IDto
{
    public int PostId { get; set; }
    public string ImageUrl { get; set; } = null!;
}
