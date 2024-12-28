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
}
