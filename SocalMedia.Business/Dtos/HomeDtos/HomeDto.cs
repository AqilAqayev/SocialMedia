using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.PostImageDtos;
using SocalMedia.Business.Dtos.PostVideoDtos;
using SocialMedia.Core.Entities.Base;
using SocialMedia.Core.Entities;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.ChatDtos;

namespace SocalMedia.Business.Dtos.HomeDtos;

public class HomeDto : IDto
{
    public List<PostDto> Posts { get; set; } = [];
    public List<PostImageDto> PostImages { get; set; } = [];
    public List<PostVideoDto> PostVideos { get; set; } = [];
    public CreatePostDto? CreatePostDto { get; set; }
    public CreateCommentDto? createCommentDto { get; set; }

}
public class MessageHomeDto : IDto
{
    public List<Chat> Chats { get; set; } = [];
    public Chat? ChatDto { get; set; }
}
//public class ChatDto : IDto
//{
//    public string? Name { get; set; }
//    public List<AppUserChat> AppUserChats { get; set; } = [];
//    public List<Message> Messages { get; set; } = [];
//    public DateTime CreatedTime { get; set; }

//}