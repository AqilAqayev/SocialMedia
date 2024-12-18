using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Dtos.PostVideoDtos;

namespace SocalMedia.Business.Dtos.HomeDtos;

public class HomeDto : IDto
{
    public List<PostDto> Posts { get; set; } = [];
    public List<PostImageDto> PostImages { get; set; } = [];
    public List<PostVideoDto> PostVideos { get; set; } = [];
    public CreatePostDto? CreatePostDto { get; set; }
}
