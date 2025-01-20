using SocialMedia.Core.Entities;

namespace SocalMedia.Business.UiServices.Abstractions;

public interface IAdminService
{
    Task<List<string>> GetAllRolesAsync();
    Task<AppUser?> GetUserByIdAsync(string userId);
    Task<string?> GetUserRoleAsync(AppUser user);
    Task<bool> UpdateUserRoleAsync(AppUser user, string newRole);
    Task<bool> UpdateUserStatusAsync(string userId, bool isDisabled);

}
