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
            RedirectToAction("Index", "Home");
        }
        int postId = await _postService.CreatePostAsync(createPostDto);
        return Json(postId);
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

        };


        post.Comments.Add(comment);

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

        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            return BadRequest();

        var isExistParent = await _context.Comments.AnyAsync(x => x.Id == dto.ParentId && x.ParentId == null);

        if (!isExistParent)
            return BadRequest();


        var isExistPost = await _context.Posts.AnyAsync(x => x.Id == dto.PostId);

        if (!isExistPost)
            return BadRequest();

        Comment comment = new()
        {
            Text = dto.Text,
            AppUserId = userId,
            PostId = dto.PostId,
            ParentId = dto.ParentId,
        };

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();


        string returnUrl = Request.GetReturnUrl();

        return Redirect(returnUrl);
    }
}
