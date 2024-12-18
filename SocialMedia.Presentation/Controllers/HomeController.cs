using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Dtos.HomeDtos;
using SocalMedia.Business.Services.Abstractions;
using SocialMedia.Presentation.Models;
using System.Diagnostics;

namespace SocialMedia.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPostImageService _postImageService;
        private readonly IPostVideoService _postVideoService;

        public HomeController(IPostService postService, IPostImageService postImageService, IPostVideoService postVideoService)
        {
            _postService = postService;
            _postImageService = postImageService;
            _postVideoService = postVideoService;
        }

        public async Task<IActionResult> Index()
        {
            HomeDto homeDto = new HomeDto
            {
                Posts = await _postService.GetAllAsync(),
                PostImages= await _postImageService.GetAllAsync(),
                PostVideos = await _postVideoService.GetAllAsync(),
                
            };    
            return View(homeDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
