using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Dtos.ProfileDtos;
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

    [HttpPost]
    public async Task<IActionResult> Bio(ProfileDto model)
    {
        await _profileService.BioCreate(model.BioNews);
        return RedirectToAction("Index", "Profile");
    }

    public async Task<IActionResult> ProfileUser(string UserId)
    {
        var profileDto = await _profileService.GetProfileOther(UserId);
        return View(profileDto);
    }
}
