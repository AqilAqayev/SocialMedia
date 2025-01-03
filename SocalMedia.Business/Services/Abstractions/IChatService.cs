using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IChatService : ICrudService<Chat, CreateChatDto, UpdateChatDto, ChatDto>
{
    Task CreateChatIfMutualFollowAsync(string userId, string friendId);
    Task<List<ChatDto>> GetUserChatsAsync(string userId);

}