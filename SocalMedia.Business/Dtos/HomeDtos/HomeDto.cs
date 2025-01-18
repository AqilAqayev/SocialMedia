using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.StoryDtos;

namespace SocalMedia.Business.Dtos.HomeDtos;

public class HomeDto : IDto
{
    public List<PostDto> Posts { get; set; } = [];
    public List<StoryDto> Stories { get; set; } = [];
    public CreatePostDto? CreatePostDto { get; set; }
    public CreateStoryDto? CreateStoryDto { get; set; }
    public CreateCommentDto? createCommentDto { get; set; }
    public CommentReplyDto? commentReplyDto { get; set; }

}