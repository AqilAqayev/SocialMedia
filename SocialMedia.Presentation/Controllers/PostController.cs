using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business;
using SocalMedia.Business.Dtos.CommentDtos;
using SocalMedia.Business.Services.Abstractions;
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


    public PostController(IPostService postService, UserManager<AppUser> userManager, AppDbContext context)
    {
        _postService = postService;
        _userManager = userManager;
        _context = context;
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
    public async Task<IActionResult> PostComment(CreateCommentDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();

        var post = await _context.Posts.Include(x => x.Comments.Where(x => x.ParentId == null)).FirstOrDefaultAsync(x => x.Id == dto.PostId);

        if (post is null)
            return BadRequest();

        Comment comment = new()
        {
            Text = dto.Text,
            Rating = dto.Rating,
            AppUserId = userId,
            PostId = dto.PostId,
            CreatedTime = DateTime.UtcNow,
            CreatedBy =user.Id

        };


        post.Comments.Add(comment);
        post.CommentCount++;
        await _context.Comments.AddAsync(comment);

        var avaragePoint = Math.Round((decimal)(post.Comments!.Sum(x => (int)x.Rating)) / (decimal)post.Comments.Count);

        //post.rating = (int)avaragepoint;

        _context.Posts.Update(post);
        await _context.SaveChangesAsync();

        string returnUrl = Request.GetReturnUrl();

        return Redirect(returnUrl);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ReplyComment(CommentReplyDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

        if (string.IsNullOrEmpty(userId))
            return BadRequest("User is not authenticated.");

        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return BadRequest("User not found.");

        if (dto.ParentId <= 0 || dto.PostId <= 0 || string.IsNullOrEmpty(dto.Text))
            return BadRequest("Invalid input data.");

        var parentComment = await _context.Comments
            .FirstOrDefaultAsync(x => x.Id == dto.ParentId && x.ParentId == null);
        if (parentComment is null)
            return BadRequest("Parent comment does not exist.");

        var post = await _context.Posts
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(x => x.Id == dto.PostId);
        if (post is null)
            return BadRequest("Post not found.");

        Comment replyComment = new()
        {
            Text = dto.Text,
            ParentId = dto.ParentId,
            PostId = dto.PostId,
            AppUserId = userId,
            CreatedBy = user.Id,
            CreatedTime = DateTime.UtcNow
        };

        await _context.Comments.AddAsync(replyComment);
        post.CommentCount++;

        _context.Posts.Update(post);
        await _context.SaveChangesAsync();

        string returnUrl = Request.GetReturnUrl();
        return Redirect(returnUrl);
    }

}
