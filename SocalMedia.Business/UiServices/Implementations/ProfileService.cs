using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.Dtos.ProfileDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.UiServices.Implementations;

internal class ProfileService : IProfileService
{
    private readonly IHttpContextAccessor _http;
    private readonly UserManager<AppUser> _userManager;
    private readonly IPostService _postService;
    private readonly IMapper _mapper;
    private readonly IPostImageService _postImageService;
    private readonly IFriendService _friendService;

    public ProfileService(IHttpContextAccessor http, UserManager<AppUser> userManager, IPostService postService, IMapper mapper, IPostImageService postImageService, IFriendService friendService)
    {
        _http = http;
        _userManager = userManager;
        _postService = postService;
        _mapper = mapper;
        _postImageService = postImageService;
        _friendService = friendService;
    }

    public async Task<ProfileDto> GetProfile()
    {
        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";

        if (string.IsNullOrEmpty(userId))
        {
            throw new NotFoundException("User not found");
        }
        var posts = await _postService.GetAllPostAsync(x => x.UserId == userId);


        var imagesDto = new List<string>();

        foreach (var post in posts)
        {
            var postImages = await _postImageService.GetAllAsync(x => x.PostId == post.Id);
            imagesDto.AddRange(postImages.Select(img => img.ImageUrl));
        }

        var postDto = _mapper.Map<List<PostDto>>(posts);

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        var postCount = posts.Count;
        var closedFriend = await _friendService.GetFriendsWithStatusAsync(userId);
        var closedFriendsDto = closedFriend
        .Where(f => f.IsClosedFriend) 
        .Select(f => new FriendClosed
        {
            Name = f.Friend.UserName,
            ProfileImage = f.Friend.ProfilePhotoUrl,
            Id = f.Friend.Id
        })
        .ToList();
        return new ProfileDto
        {
            Email = user.Email,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Posts = postDto,
            ImageUrls = imagesDto,
            PostCount = postCount,
            FollowCount = user.FollowerCount,
            FollowingCount = user.FollowingCount,
            ProfilePhoto = user.ProfilePhotoUrl,
            BioNews = user.Biography,
            FriendCloseds = closedFriendsDto,
            PostDtos =posts,

            
            

        };
    }
    public async Task<ProfileOther> GetProfileOther(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            throw new NotFoundException("User not found");

        string currentUserId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";

        bool isAcceptedFollower = true;

        var posts = await _postService.GetAllPostAsync(x => x.UserId == userId);

        var postDto = _mapper.Map<List<PostDto>>(posts);
      
        if (user.IsPrivate)
        {
            isAcceptedFollower = await _friendService.IsAcceptedFollowerAsync(userId, currentUserId);
        }
        bool btn = await _friendService.IFollowerAsync(userId, currentUserId);
        if (user.IsPrivate && !isAcceptedFollower)
        {
            return new ProfileOther
            {
                userId = user.Id,
                UserName = user.UserName,
                ProfilePhoto = user.ProfilePhotoUrl,
                PostCount = posts.Count,
                FollowCount = user.FollowerCount,
                FollowingCount = user.FollowingCount,
                Status = false ,
                FollowBtn= btn
               
            };
        }


        return new ProfileOther
        {
            userId = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Posts = postDto,
            PostCount = posts.Count,
            FollowCount = user.FollowerCount,
            FollowingCount = user.FollowingCount,
            ProfilePhoto = user.ProfilePhotoUrl,
            Status = true,
            FollowBtn = btn
        };
    }

    public async Task BioCreate(string bio)
    {
        string userId = _http.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";

        if (string.IsNullOrEmpty(userId))
        {
            throw new NotFoundException("User not found");
        }

        AppUser user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        user.Biography = bio;
        await _userManager.UpdateAsync(user);
    }
}
