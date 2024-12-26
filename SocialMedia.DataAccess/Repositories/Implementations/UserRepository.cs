using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using System.Linq.Expressions;

namespace SocialMedia.DataAccess.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AppUser>> GetAllAsync(Expression<Func<AppUser, bool>> filter)
    {
        return await _context.Users.Where(filter).ToListAsync();
    }
}
