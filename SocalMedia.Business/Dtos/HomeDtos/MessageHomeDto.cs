using SocalMedia.Business.Dtos.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Dtos.HomeDtos;

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