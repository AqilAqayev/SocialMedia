using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.FollowDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class FollowService : CrudService<Follow, CreateFollowDto, UpdateFollowDto, FollowDto>, IFollowService
{
    private readonly IHttpContextAccessor _http;
    private readonly UserManager<AppUser> _userManager;
    private readonly IFollowRepository _followRepository;
    private readonly IChatService _chatService;


    public FollowService(IFollowRepository repository, IMapper mapper, IHttpContextAccessor http, IFollowRepository followRepository, UserManager<AppUser> userManager, IChatService chatService)
        : base(repository, mapper)
    {
        _http = http;
        _followRepository = followRepository;
        _userManager = userManager;
        _chatService = chatService;
    }

    public async Task Follow(string followedId)
    {
        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            throw new NotFoundException("User not found");
        }

        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        AppUser followed = await _userManager.FindByIdAsync(followedId);
        if (followed == null)
        {
            throw new NotFoundException("Followed user not found");
        }

        bool isAlreadyFollowing = await _followRepository.AnyAsync(f =>
            f.FollowerId == userId && f.FollowingId == followedId);

        if (isAlreadyFollowing)
        {
            throw new NotFoundException("You are already following this user or follow request is pending.");
        }

        Follow following = new Follow
        {
            FollowingId = followedId,
            FollowerId = userId,
            Status = !followed.IsPrivate 
        };

        if (!followed.IsPrivate)
        {
            following.Status = true; 
            followed.FollowerCount++;
            user.FollowingCount++;
        }

        

        await _followRepository.CreateAsync(following);
        await _followRepository.SaveChangesAsync();
        bool isMutualFollow = await _followRepository.AnyAsync(f =>
        f.FollowerId == followedId && f.FollowingId == userId);

        if (!isMutualFollow)
        {
            await _chatService.CreateChatIfMutualFollowAsync(userId, followedId);
        }
    }


}
