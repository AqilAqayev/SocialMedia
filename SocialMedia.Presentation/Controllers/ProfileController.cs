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
        var PrifileDto = await _profileService.GetProfile();
        return View(PrifileDto);
    }
}
