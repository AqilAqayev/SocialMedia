namespace SocalMedia.Business.UiServices.Abstractions
{
    public interface ISharedService
    {
        Task CreateChatIfMutualFollowAsync(string userId, string followedId);
        //Task DeleteChatIfNoMutualFollowAsync(string userId, string unfollowedId);
    }
}
