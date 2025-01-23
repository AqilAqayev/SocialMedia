using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Dtos.MessageDtos;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Dtos.ChatDtos;

public class ChatDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UnreadMessagesCount { get; set; }

    public List<MessageDto> Messages { get; set; } = [];

    public string? ProfileUrl { get; set; }
}

public class CreateChatDto : IDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
}
public class UpdateChatDto : IDto
{
    public int ChatId { get; set; }
    public string UserName { get; set; } = null!;
}

