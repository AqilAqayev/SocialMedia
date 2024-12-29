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

}
