using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.DataAccess.Repositories.Abstraction;
using SocialMedia.DataAccess.Repositories.Implementations.Generic;

namespace SocialMedia.DataAccess.Repositories.Implementations;

internal class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}

internal class SendNatficationRepository : Repository<SendNatfication>, ISendNatficationRepository
{
    public SendNatficationRepository(AppDbContext context) : base(context)
    {
    }
}
