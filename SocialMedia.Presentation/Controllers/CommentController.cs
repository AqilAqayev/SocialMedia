using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Services.Abstractions;
using SocialMedia.Presentation.Extensions;

namespace SocialMedia.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public CommentController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }


        public async Task<IActionResult> Delete(int commentUserId,int postUserId)
        {
            await _commentService.DeleteCommentAsync(commentUserId, postUserId);

            string returnUrl = Request.GetReturnUrl();
            return Redirect(returnUrl);
        }


    }
}
