using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;
using System.Linq.Expressions;

namespace SocialMedia.DataAccess.Repositories.Abstraction;

public interface IFollowRepository : IRepository<Follow>
{
    Task<bool> AnyAsync(Expression<Func<Follow, bool>> predicate);
    Task<List<(AppUser Friend, bool IsClosedFriend)>> GetFriendsWithStatusAsync(string userId);
}