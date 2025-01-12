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
       var homeDto = await _homeService.GetHomeDto();
        return View(homeDto);
    }

    [HttpGet]
    public  IActionResult Search()
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
    [HttpGet]
    public async Task<IActionResult> GetMorePosts(int page = 1, int pageSize = 10)
    {
        var posts = await _homeService.GetPaginatedHomeDtoAsync(page, pageSize);
        return Json(new { posts = posts.Posts });
    }
}
