using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SocalMedia.Business.Services.Abstractions;

namespace SocialMedia.Presentation.Controllers;

public class LikeController : Controller
{
    private readonly IPostService _postService;

    public LikeController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IActionResult> PostLike(int postId)
    {
        var like =await _postService.LikePostAsync(postId);
        return RedirectToAction("Index", "Home");
    }
}
