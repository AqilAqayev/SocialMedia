using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction;

namespace SocalMedia.Business.UiServices.Implementations;

internal class FriendService : IFriendService
{
    private readonly IFollowRepository _friendRepository;

    public FriendService(IFollowRepository friendRepository)
    {
        _friendRepository = friendRepository;
    }

    public async Task<List<(AppUser Friend, bool IsClosedFriend)>> GetFriendsWithStatusAsync(string userId)
    {
        return await _friendRepository.GetFriendsWithStatusAsync(userId);
    }
    public async Task<bool> IsAcceptedFollowerAsync(string userId, string followerId)
    {
        if (string.IsNullOrEmpty(followerId) || string.IsNullOrEmpty(userId))
        {
            return false;
        }

        return await _friendRepository.AnyAsync(f =>
          f.FollowingId == userId &&
          f.FollowerId == followerId &&
          f.Status == true);
    }

    public async Task<bool> IFollowerAsync(string userId, string followerId)
    {
        if (string.IsNullOrEmpty(followerId) || string.IsNullOrEmpty(userId))
        {
            return false;
        }

        return await _friendRepository.AnyAsync(f =>
          f.FollowingId == userId &&
          f.FollowerId == followerId);
    }
}
