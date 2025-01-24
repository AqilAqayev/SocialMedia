using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IChatService : ICrudService<Chat, CreateChatDto, UpdateChatDto, ChatDto>
{
    Task<ChatDto> CreateChatIfMutualFollowAsync(string friendId);
    Task DeleteChatIfNoMutualFollowAsync(string otherUserId);
    Task<List<ChatDto>> GetUserChatsAsync(string userId);
    Task<ChatDto?> GetChatIfExistsAsync(int id);
    Task<Message?> SendMessageAsync(int chatId, string text, string userId, Message message);
    Task<Message> CreateMessage(string text, int chatId);




}