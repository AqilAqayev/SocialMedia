using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class PostRepository : Repository<Post>, IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Post?> GetPostWithCommentsAsync(int postId)
    {
        return await _context.Posts
            .Include(p => p.Comments.Where(c => c.ParentId == null))
            .FirstOrDefaultAsync(p => p.Id == postId);
    }
}
