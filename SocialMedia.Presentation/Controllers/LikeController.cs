using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Services.Abstractions;

namespace SocialMedia.Presentation.Controllers;
public class LikeController : Controller
{
    private readonly IPostService _postService;

    public LikeController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> PostLike(int postId)
    {
        var like = await _postService.LikePostAsync(postId);

        var likeCount = await _postService.GetPostLikeCountAsync(postId);

        return Json(new
        {
            success = true,
            isLiked = like,
            likeCount = likeCount
        });
    }

}
