using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business.Dtos.ChatDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class ChatService : CrudService<Chat, CreateChatDto, UpdateChatDto, ChatDto>, IChatService
{
    private readonly IFriendService _friendService;
    private readonly IChatRepository _chatRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IFollowRepository _followRepository;

    public ChatService(IChatRepository repository, IMapper mapper, IFriendService friendService, IChatRepository chatRepository, UserManager<AppUser> userManager, IFollowRepository followRepository/*, IFollowService followService*/) : base(repository, mapper)
    {
        _friendService = friendService;
        _chatRepository = chatRepository;
        _userManager = userManager;
        _mapper = mapper;
        _followRepository = followRepository;
        //_followService = followService;
    }
    //public async Task DeleteChatIfNoMutualFollowAsync(string userId, string otherUserId)
    //{
    //    bool isMutualFollow = await _followRepository.AnyAsync(f =>
    //        (f.FollowerId == userId && f.FollowingId == otherUserId) ||
    //        (f.FollowerId == otherUserId && f.FollowingId == userId));

    //    if (!isMutualFollow)
    //    {
    //        var chat = await _chatRepository.GetAll()
    //            .FirstOrDefaultAsync(c => c.AppUserChats.Any(ac => ac.AppUserId == userId) &&
    //                                      c.AppUserChats.Any(ac => ac.AppUserId == otherUserId));
    //        if (chat != null)
    //        {
    //            _chatRepository.Delete(chat);
    //            await _chatRepository.SaveChangesAsync();
    //        }
    //    }
    //}

    public async Task CreateChatIfMutualFollowAsync(string userId, string friendId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var friend = await _userManager.FindByIdAsync(friendId);

        if (user == null || friend == null)
        {
            throw new NotFoundException("One of the users does not exist.");
        }

        var existingChat = await _chatRepository.GetAll()
            .Where(c => c.AppUserChats.Any(ac => ac.AppUserId == userId) &&
                        c.AppUserChats.Any(ac => ac.AppUserId == friendId))
            .AnyAsync();

        if (!existingChat)
        {
           
            var chatName = $"{user.UserName}-{friend.UserName}";

            var chat = new Chat
            {
                Name = chatName,
                CreatedTime = DateTime.UtcNow
            };

            chat.AppUserChats.Add(new AppUserChat { AppUserId = userId });
            chat.AppUserChats.Add(new AppUserChat { AppUserId = friendId });

            await _chatRepository.CreateAsync(chat);
            await _chatRepository.SaveChangesAsync();
        }
    }

    public async Task<List<ChatDto>> GetUserChatsAsync(string userId)
    {
        var chats = await _chatRepository.GetAll()
        .Where(c => c.AppUserChats.Any(ac => ac.AppUserId == userId))
        .ToListAsync();

        return  _mapper.Map<List<ChatDto>>(chats);
    }
}