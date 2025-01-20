using Microsoft.AspNetCore.Identity;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;

namespace SocalMedia.Business.UiServices.Implementations;

internal class AdminService : IAdminService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<string>> GetAllRolesAsync()
    {
        var list = _roleManager.Roles
            .Where(role => role.Name != "Admin")
            .Select(r => r.Name)
            .ToList();
        return list;
    }

    public async Task<AppUser?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<string?> GetUserRoleAsync(AppUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        return roles.FirstOrDefault();
    }



    public async Task<bool> UpdateUserRoleAsync(AppUser user, string newRole)
    {
        var currentRoles = await _userManager.GetRolesAsync(user);
        if (currentRoles.Any())
        {
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
                return false;
        }

        var addResult = await _userManager.AddToRoleAsync(user, newRole);
        return addResult.Succeeded;
    }

    public async Task<bool> UpdateUserStatusAsync(string userId, bool isDisabled)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        user.IsDisabled = isDisabled;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

}
