using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.UiServices.Abstractions;

namespace SocialMedia.Presentation.Controllers;

public class ProfileController : Controller
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public async Task<IActionResult> Index()
    {
        var profileDto = await _profileService.GetProfile();
        return View(profileDto);
    }

    public async Task<IActionResult> ProfileUser(string UserId)
    {
        var profileDto = await _profileService.GetProfileOther(UserId);
        return View(profileDto);
    }
}
