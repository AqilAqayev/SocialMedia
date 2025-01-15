using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.UiServices.Abstractions;

namespace SocalMedia.Business.UiServices.Implementations;

internal class SharedService : ISharedService
{
    private readonly IChatService  _chatService;

    public SharedService(IChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task CreateChatIfMutualFollowAsync(string userId, string followedId)
    {
        await _chatService.CreateChatIfMutualFollowAsync(followedId);
    }

    //public async Task DeleteChatIfNoMutualFollowAsync(string userId, string unfollowedId)
    //{
    //    await _chatService.DeleteChatIfNoMutualFollowAsync(userId, unfollowedId);
    //}
}
