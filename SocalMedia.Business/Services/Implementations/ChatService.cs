using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Dtos.MessageDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Hubs;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.StaticFiles;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;
using System.Security.Claims;

namespace SocalMedia.Business.Services.Implementations;

public class ChatService : CrudService<Chat, CreateChatDto, UpdateChatDto, ChatDto>, IChatService
{
    private readonly IFriendService _friendService;
    private readonly IChatRepository _chatRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;
    private readonly IHttpContextAccessor _http;
    private readonly IMessageService _messageService;
    private readonly IHubContext<ChatHub> _chatHub;
    private readonly IMessageRepository _messageRepository;


    public ChatService(IChatRepository repository, IMapper mapper, IFriendService friendService, IChatRepository chatRepository, UserManager<AppUser> userManager, IFollowRepository followRepository/*, IFollowService followService*/, IHttpContextAccessor http, IMessageService messageService, IHubContext<ChatHub> chatHub, IMessageRepository messageRepository) : base(repository, mapper)
    {
        _friendService = friendService;
        _chatRepository = chatRepository;
        _userManager = userManager;
        _mapper = mapper;
        _followRepository = followRepository;
        _http = http;
        _messageService = messageService;
        _chatHub = chatHub;
        _messageRepository = messageRepository;
    }

    public async Task<Message> CreateMessage(string text, int chatId)
    {
        var chat = await GetChatIfExistsAsync(chatId);

        var userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ;
        if(userId == null )
        {
            throw new NotFoundException("User not found");
        }
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            throw new NotFoundException("User not found");

        Message message = new()
        {
            Text = text,
            ChatId = chatId,
            SenderId = userId,
        };

        message.Chats = null;

        await _messageRepository.CreateAsync(message);
        await _messageRepository.SaveChangesAsync();
        return message;
    }
    public async Task DeleteChatIfNoMutualFollowAsync(string otherUserId)
    {
        if (otherUserId == null)
        {
            throw new NotFoundException();
        }
        string userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

        bool isMutualFollow = await _followRepository.AnyAsync(f =>
            (f.FollowerId == userId && f.FollowingId == otherUserId) ||
            (f.FollowerId == otherUserId && f.FollowingId == userId));

        if (!isMutualFollow)
        {
            var chat = await _chatRepository.GetAll()
                .FirstOrDefaultAsync(c => c.AppUserChats.Any(ac => ac.AppUserId == userId) &&
                                          c.AppUserChats.Any(ac => ac.AppUserId == otherUserId));
            if (chat != null)
            {
                await _chatRepository.Delete(chat);
                await _chatRepository.SaveChangesAsync();
            }
        }
    }

    public async Task<ChatDto> CreateChatIfMutualFollowAsync(string friendId)
    {
        if (string.IsNullOrEmpty(friendId))
        {
            throw new NotFoundException("Friend not found");
        }

        string userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

        var user = await _userManager.FindByIdAsync(userId);
        var friend = await _userManager.FindByIdAsync(friendId);

        if (user == null || friend == null)
        {
            throw new NotFoundException("One of the users does not exist.");
        }

        var existingChat = await _chatRepository.GetAll()
            .Where(c => c.AppUserChats.Any(ac => ac.AppUserId == userId) &&
                        c.AppUserChats.Any(ac => ac.AppUserId == friendId))
            .FirstOrDefaultAsync();

        if (existingChat != null)
        {
            return _mapper.Map<ChatDto>(existingChat);
        }

        var chatName = $"{user.UserName}-{friend.UserName}";

        var chat = new Chat
        {
            Name = chatName,
            CreatedTime = DateTime.UtcNow,
            AppUserChats = new List<AppUserChat>
            {
                new AppUserChat { AppUserId = userId },
                new AppUserChat { AppUserId = friendId }
            }
        };

        await _chatRepository.CreateAsync(chat);
        await _chatRepository.SaveChangesAsync();

        return _mapper.Map<ChatDto>(chat);
    }
    public async Task<List<ChatDto>> GetUserChatsAsync(string userId)
    {
        var chats = await _chatRepository.GetAll()
            .Include(c => c.AppUserChats)
            .ThenInclude(ac => ac.AppUser)
            .Include(c => c.Messages)
            .Where(c => c.AppUserChats.Any(ac => ac.AppUserId == userId))
            .ToListAsync();

        return chats.Select(chat =>
        {
            var otherUser = chat.AppUserChats
                .FirstOrDefault(ac => ac.AppUserId != userId)?.AppUser;

            var unreadMessagesCount = chat.Messages
                .Where(m => m.SenderId != userId && !m.IsRead)
                .Count();

            return new ChatDto
            {
                Id = chat.Id,
                Name = otherUser?.UserName,
                ProfileUrl = otherUser?.ProfilePhotoUrl,
                UnreadMessagesCount = unreadMessagesCount
            };
        }).ToList();


    }


    public async Task MarkMessagesAsReadAsync(int chatId, string userId)
    {
        var messages = await _messageService.GetAllAsync(m => m.ChatId == chatId && m.SenderId != userId && !m.IsRead);

        if (messages.Any())
        {
            foreach (var message in messages)
            {
                message.IsRead = true;
            }


        }
        await _messageService.SaveChangesAsync();
    }

    public async Task MarkMessagesAsReadAndNotifyAsync(int chatId, string userId)
    {
        await MarkMessagesAsReadAsync(chatId, userId);


        await _chatHub.Clients.Group(chatId.ToString())
            .SendAsync("MessagesMarkedAsRead", chatId, userId);
    }

    public async Task<ChatDto?> GetChatIfExistsAsync(int id)
    {
        var userId = _http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            throw new NotFoundException();
        var chat = await _chatRepository.GetChatByIdAndUserIdAsync(id, userId);
        if (chat is null)
        {
            throw new NotFoundException();
        }

        var dto = _mapper.Map<ChatDto>(chat);
        var otherUser = chat.AppUserChats
       .FirstOrDefault(ac => ac.AppUserId != userId)?.AppUser;

        dto.Name = otherUser?.UserName;
        dto.ProfileUrl = otherUser?.ProfilePhotoUrl;
        return dto;
    }
    public async Task<Message?> SendMessageAsync(int chatId, string text, string userId, Message message)
    {
        var chat = await _chatRepository.GetChatByIdAndUserIdAsync(chatId, userId);

       


        foreach (var userChat in chat.AppUserChats.Where(x => x.AppUserId != userId))
        {
            var connection = HubDatas.Connections.FirstOrDefault(x => x.UserId == userChat.AppUserId);
            if (connection is { })
            {
                foreach (var id in connection.ConnectionIds)
                {
                    await _chatHub.Clients.Client(id).SendAsync("ReceiveMessage", message);
                }
            }
        }

        return message;
    }
}