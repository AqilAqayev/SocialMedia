using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.FollowDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class FollowService : CrudService<Follow, CreateFollowDto, UpdateFollowDto, FollowDto>, IFollowService
{
    private readonly IHttpContextAccessor _http;
    private readonly UserManager<AppUser> _userManager;
    private readonly IFollowRepository followRepository;
    public FollowService(IFollowRepository repository, IMapper mapper, IHttpContextAccessor http, IFollowRepository followRepository, UserManager<AppUser> userManager) : base(repository, mapper)
    {
        _http = http;
        this.followRepository = followRepository;
        _userManager = userManager;
    }

     
    public async Task Follow(string followedId)
    {
        
    string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId is null)
        {
            throw new Exception("User not found");
        }
        AppUser user = await _userManager.FindByIdAsync(userId) ;
        if (user == null) 
        {
            throw new Exception("User not found");
        }
        AppUser followed = await _userManager.FindByIdAsync(followedId);
        
        Follow following = new Follow
        {

            FollowingId = followedId,
            FollowerId = userId,
            Status = false

        };
        if (!followed.IsPrivate)
        {
            following.Status = true;
            followed.FollowerCount++;
            user.FollowingCount++;
        }

        await followRepository.CreateAsync(following);
        await followRepository.SaveChangesAsync();
    }
}