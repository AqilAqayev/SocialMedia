using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;

namespace SocialMedia.DataAccess.Repositories.Abstraction;

public interface IChatRepository : IRepository<Chat>
{
    Task<Chat?> GetChatByIdAndUserIdAsync(int id, string userId);

}
