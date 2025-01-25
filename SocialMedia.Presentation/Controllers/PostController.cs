using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Services.Abstractions;
using System.Security.Claims;

namespace SocialMedia.Presentation.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;


    public PostController(IPostService postService)
    {
        _postService = postService;
        
    }

    [HttpPost]
    [Authorize]

    public async Task<IActionResult> Create(CreatePostDto createPostDto)
    { 
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", "Home");
        }

        int postId = await _postService.CreatePostAsync(createPostDto);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _postService.DeleteAsync(id);

        return RedirectToAction("Index", "Profile");
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { success = false, message = "Unauthorized" });

        var newDto = await _postService.AddCommentAsync(dto, userId);

        return PartialView("_CommentPartial", newDto);
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ReplyComment([FromBody]CommentReplyDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var newDto = await _postService.AddReplyAsync(dto, userId);

        return PartialView("_ReplyCommentPartial", newDto);
    }


    //[HttpPost]
    //[Authorize]
    //public async Task<IActionResult> Delete(string id)
    //{
       
    //}


}
