using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class ChatRepository : Repository<Chat>, IChatRepository
{
    private readonly AppDbContext _context;
    public ChatRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Chat?> GetChatByIdAndUserIdAsync(int id, string userId)
    {
        return await _context.Chats
            .Include(x => x.AppUserChats)
                .ThenInclude(x => x.AppUser)
                .Include(X => X.User)
            .Include(x => x.Messages)
            .FirstOrDefaultAsync(x => x.Id == id && x.AppUserChats.Any(x => x.AppUserId == userId));
    }
}