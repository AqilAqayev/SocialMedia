using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class StoryRepository : Repository<Story>, IStoryRepository
{
    private readonly AppDbContext _context;

    public StoryRepository(AppDbContext context) : base(context)
    {
        _context=context;
    }

    public Task<List<Story>> GetAllActiveStoriesAsync()
    {
        var now = DateTime.UtcNow;
        var story =  _context.Set<Story>()
            .Where(story => story.CreatedTime.AddHours(24) > now).Include(x=>x.StoryVideos).Include(x=>x.StoryImages)
            .Include(s=>s.User)
            .ToListAsync();

        return story;
    }
}
