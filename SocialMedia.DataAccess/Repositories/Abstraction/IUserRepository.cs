using SocialMedia.Core.Entities;
using System.Linq.Expressions;

namespace SocialMedia.DataAccess.Repositories.Abstraction;

public interface IUserRepository
{
    Task<List<AppUser>> GetAllAsync(Expression<Func<AppUser, bool>> filter);
}
