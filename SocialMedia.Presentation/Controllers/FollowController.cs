using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Services.Abstractions;
using System.Drawing;

namespace SocialMedia.Presentation.Controllers
{
    public class FollowController : Controller
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }


        public async Task<IActionResult> Follow(string followId)
        {
            await _followService.Follow(followId);
            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> Unfollow(string followId)
        //{
        //    await _followService.Unfollow(followId);
        //    return RedirectToAction("Index", "Home");
        //}


    }
}
