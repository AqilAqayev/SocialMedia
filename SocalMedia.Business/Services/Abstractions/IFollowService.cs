using SocalMedia.Business.Dtos.FollowDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IFollowService : ICrudService<Follow, CreateFollowDto, UpdateFollowDto, FollowDto>
{
    public Task Follow(string followedId);
    //public Task Unfollow(string unfollowedId);
}