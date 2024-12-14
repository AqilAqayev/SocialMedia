using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class StoryVideoRepository : Repository<StoryVideo>, IStoryVideoRepository
{
    public StoryVideoRepository(AppDbContext context) : base(context)
    {
    }
}