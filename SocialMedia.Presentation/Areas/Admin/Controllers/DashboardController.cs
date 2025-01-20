using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business.Dtos.AdminDtos;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;

namespace SocialMedia.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAdminService _adminService;

    public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IAdminService adminService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _adminService = adminService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var filteredUsers = new List<UserDto>();

        foreach (var user in users)
        {
            if (!(await _userManager.IsInRoleAsync(user, "Admin")))
            {
                filteredUsers.Add(new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsEmailConfirmed = user.EmailConfirmed,
                    IsDisabled = user.IsDisabled,
                    IsPrivate = user.IsPrivate
                });
            }
        }

        return View(filteredUsers);
    }

    public async Task<IActionResult> Update(string id)
    {
        var user = await _adminService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();

        var viewModel = new UpdateUserStatusDto
        {
            UserId = id,
            IsDisabled = user.IsDisabled
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateUserStatusDto model)
    {
        var result = await _adminService.UpdateUserStatusAsync(model.UserId, model.IsDisabled);
        if (!result)
            ModelState.AddModelError("", "User status update failed!");

        return RedirectToAction(nameof(Index));
    }
}
