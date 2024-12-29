using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Dtos.HomeDtos;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using static System.Net.WebRequestMethods;

namespace SocialMedia.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IPostService _postService;
    private readonly IPostImageService _postImageService;
    private readonly IPostVideoService _postVideoService;
    private readonly IHomeService _homeService;

    public HomeController(IPostService postService, IPostImageService postImageService, IPostVideoService postVideoService, IHomeService homeService)
    {
        _postService = postService;
        _postImageService = postImageService;
        _postVideoService = postVideoService;
        _homeService = homeService;
    }

    public async Task<IActionResult> Index()
    {
        string userId =HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var post = await _postService.GetAllPostAsync(x=>x.UserId!=userId);
        //var image = await _postImageService.GetAllAsync();
        //var video = await _postVideoService.GetAllAsync();

        HomeDto homeDto = new HomeDto
        {
            //Posts = await _postService.GetAllAsync(),
            //PostImages = await _postImageService.GetAllAsync(),
            //PostVideos = await _postVideoService.GetAllAsync(),

            Posts = post,
            //PostImages=image,
            //PostVideos=video

        };    
        return View(homeDto);
    }

    [HttpGet]
    public async Task<IActionResult> Search()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new List<AppUser>()); 
        }

        var users = await _homeService.SearchUsersAsync(query);
        return View(users);
    }
}
