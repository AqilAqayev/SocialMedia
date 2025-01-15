using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.FollowDtos;
using SocalMedia.Business.Dtos.SendNatficationDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.Services.Implementations.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Entities.Base;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.Services.Implementations;

public class FollowService : CrudService<Follow, CreateFollowDto, UpdateFollowDto, FollowDto>, IFollowService
{
    private readonly IHttpContextAccessor _http;
    private readonly UserManager<AppUser> _userManager;
    private readonly IFollowRepository _followRepository;
    private readonly ISendNatficationService _sendNatficationService;
    private readonly IMapper _mapper;


    public FollowService(IFollowRepository repository, IMapper mapper, IHttpContextAccessor http, IFollowRepository followRepository, UserManager<AppUser> userManager,ISendNatficationService sendNatficationService)
        : base(repository, mapper)
    {
        _http = http;
        _followRepository = followRepository;
        _userManager = userManager;
        _mapper = mapper;
        _sendNatficationService = sendNatficationService;
    }

    public async Task Follow(string followedId)
    {
        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";

        if (userId is null)
        {
            throw new NotFoundException("User not found");
        }

        var user = await _userManager.FindByIdAsync(userId) ;
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var followed = await _userManager.FindByIdAsync(followedId);
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
        else
        {
          await SendNotfication(followedId);

        }



        await _followRepository.CreateAsync(following);
        await _followRepository.SaveChangesAsync();
        bool isMutualFollow = await _followRepository.AnyAsync(f =>
        f.FollowerId == followedId && f.FollowingId == userId);

       
    }

    public async Task Unfollow(string followedId)
    {
        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
        if (userId is null)
        {
            throw new NotFoundException("User not found");
        }

        var user = await _userManager.FindByIdAsync(userId);

        if( user == null)
        {
             throw new NotFoundException("User not found");
        }

        var followed = await _userManager.FindByIdAsync(followedId);

        if(followed == null)
        {
            throw new NotFoundException("Followed user not found");
        }

        followed.FollowerCount--;
        user.FollowingCount--;

        var foll = await _followRepository.GetAsync(f => f.FollowingId == followedId && f.FollowerId == userId);

        if (foll != null)
        {
            _followRepository.Delete(foll);
            await _followRepository.SaveChangesAsync();
        }
    }

    public async Task SendNotfication(string RecieverId)
    {
        if (RecieverId is null)
        {
            throw new NotFoundException("User not found");
        }
        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
        if (userId is null)
        {
            throw new NotFoundException("User not found");

        }

        var natfication = new SendNatfication
        {
            SenderId = userId,
            UserId = RecieverId
        };
        var natficationDto = _mapper.Map<CreateSendNatficationDto>(natfication);

        await _sendNatficationService.CreateAsync(natficationDto);

    }

    public async Task AcceptRequest(string receiverId)
    {
        if (string.IsNullOrWhiteSpace(receiverId))
        {
            throw new NotFoundException("Receiver user ID cannot be null or empty.");
        }

        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new NotFoundException("User not found.");
        }

        var followRequest = await _followRepository.GetAsync(f =>
            f.FollowerId == receiverId && f.FollowingId == userId && !f.Status);

        if (followRequest == null)
        {
            throw new NotFoundException("Follow request not found.");
        }

        followRequest.Status = true;

         _followRepository.Update(followRequest);


        var receiver = await _userManager.FindByIdAsync(receiverId);
        await _followRepository.SaveChangesAsync();

        var user = await _userManager.FindByIdAsync(userId);

        if (receiver == null || user == null)
        {
            throw new NotFoundException("User(s) not found.");
        }

        receiver.FollowingCount++;
        user.FollowerCount++;
        var notification = await _sendNatficationService.GetAsync(x=>x.UserId==userId);
        if (notification != null)
        {
            await _sendNatficationService.DeleteAsync(notification.Id);
        }

        await _followRepository.SaveChangesAsync();

        
        bool isMutualFollow = await _followRepository.AnyAsync(f =>
            f.FollowerId == userId && f.FollowingId == receiverId);


    }

    public async Task RejectRequest(string receiverId)
    {
        if (string.IsNullOrWhiteSpace(receiverId))
        {
            throw new NotFoundException("Receiver user ID cannot be null or empty.");
        }

        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new NotFoundException("User not found.");
        }

        var followRequest = await _followRepository.GetAsync(f =>
            f.FollowerId == receiverId && f.FollowingId == userId && !f.Status);

        if (followRequest == null)
        {
            throw new NotFoundException("Follow request not found.");
        }
        var notification = await _sendNatficationService.GetAsync(x => x.UserId == userId);
        if (notification != null)
        {
            await _sendNatficationService.DeleteAsync(notification.Id);
        }

        _followRepository.Delete(followRequest);
        await _followRepository.SaveChangesAsync();
    }


}
