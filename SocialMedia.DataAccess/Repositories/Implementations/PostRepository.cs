using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
}
