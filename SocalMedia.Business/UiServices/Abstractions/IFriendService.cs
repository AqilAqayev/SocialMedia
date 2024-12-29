using SocialMedia.Core.Entities;

namespace SocalMedia.Business.UiServices.Abstractions;

public interface IFriendService
{
    Task<List<(AppUser Friend, bool IsClosedFriend)>> GetFriendsWithStatusAsync(string userId);
}
