using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.PostImageDtos;

public class UpdatePostImageDto : IDto
{
    public string ImageUrl { get; set; } = null!;
}
