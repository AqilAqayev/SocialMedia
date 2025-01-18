using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Dtos.StoryDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using SocialMedia.Presentation.Extensions;
using System.Security.Claims;

namespace SocialMedia.Presentation.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _context;
    private readonly IAccountService _accountService;
    private readonly IStoryService _storyService;


    public PostController(IPostService postService, UserManager<AppUser> userManager, AppDbContext context, IAccountService accountService, IStoryService storyService)
    {
        _postService = postService;
        _userManager = userManager;
        _context = context;
        _accountService = accountService;
        _storyService = storyService;
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
    public async Task<IActionResult> ReplyComment(CommentReplyDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        await _postService.AddReplyAsync(dto, userId);
        return Redirect(Request.Headers["Referer"].ToString());
    }

}
