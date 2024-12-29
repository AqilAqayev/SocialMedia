using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;
using System.Linq.Expressions;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class FollowRepository : Repository<Follow>, IFollowRepository
{
    private readonly AppDbContext _context;

    public FollowRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<Follow, bool>> predicate)
    {
        return await _context.Set<Follow>().AnyAsync(predicate);
    }
    public async Task<List<(AppUser Friend, bool IsClosedFriend)>> GetFriendsWithStatusAsync(string userId)
    {
      

        var friendsWithStatusQuery = await _context.Follows
            .Where(f => f.FollowerId == userId)
            .GroupJoin(
                _context.Follows.Where(ff => ff.FollowingId == userId),
                f => f.FollowingId,
                ff => ff.FollowerId,
                (f, matchingFollowBacks) => new
                {
                    Friend = f.Following,
                    IsClosedFriend = matchingFollowBacks.Any()
                }
            )
            .ToListAsync(); 

        var result = friendsWithStatusQuery
            .Select(f => (f.Friend, f.IsClosedFriend))
            .ToList();

        return result;
    }


}
