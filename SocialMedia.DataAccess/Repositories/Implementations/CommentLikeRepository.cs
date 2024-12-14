using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class CommentLikeRepository : Repository<CommentLike>, ICommentLikeRepository
{
    public CommentLikeRepository(AppDbContext context) : base(context)
    {
    }
}
