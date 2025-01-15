using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;

namespace SocialMedia.DataAccess.Repositories.Abstraction;

public interface IPostRepository : IRepository<Post>
{
    Task<Post?> GetPostWithCommentsAsync(int postId);

}
