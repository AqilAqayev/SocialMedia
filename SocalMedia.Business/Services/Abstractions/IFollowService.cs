using SocalMedia.Business.Dtos.FollowDtos;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.Services.Abstractions;

public interface IFollowService : ICrudService<Follow, CreateFollowDto, UpdateFollowDto, FollowDto>
{
    Task Follow(string followedId);
    Task RejectRequest(string receiverId);
    Task AcceptRequest(string receiverId);
    Task Unfollow(string followedId);
}