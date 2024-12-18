using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business;
using SocalMedia.Business.Services.Abstractions;

namespace SocialMedia.Presentation.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto createPostDto)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index", "Home");
            }
            int postId = await _postService.CreatePostAsync(createPostDto);

            return Json(postId);
            
        }
    }
}
