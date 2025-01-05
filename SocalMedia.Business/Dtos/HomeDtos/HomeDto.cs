using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.Generic;

namespace SocalMedia.Business.Dtos.HomeDtos;

public class HomeDto : IDto
{
    public List<PostDto> Posts { get; set; } = [];
    public CreatePostDto? CreatePostDto { get; set; }
    public CreateCommentDto? createCommentDto { get; set; }
    public CommentReplyDto? commentReplyDto { get; set; }

}
//public class ChatDto : IDto
//{
//    public string? Name { get; set; }
//    public List<AppUserChat> AppUserChats { get; set; } = [];
//    public List<Message> Messages { get; set; } = [];
//    public DateTime CreatedTime { get; set; }

//}