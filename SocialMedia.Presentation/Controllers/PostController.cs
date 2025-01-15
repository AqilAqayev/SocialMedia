using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business;
using SocalMedia.Business.Dtos.CommentDtos;
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


    public PostController(IPostService postService, UserManager<AppUser> userManager, AppDbContext context, IAccountService accountService)
    {
        _postService = postService;
        _userManager = userManager;
        _context = context;
        _accountService = accountService;
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
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { success = false, message = "Unauthorized" });

        await _postService.AddCommentAsync(dto, userId);

        return Json(new { success = true, message = "Comment added successfully" });
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
