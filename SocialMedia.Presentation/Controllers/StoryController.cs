using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Dtos.StoryDtos;
using SocalMedia.Business.Services.Abstractions;

namespace SocialMedia.Presentation.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpPost]
        [Authorize]

        public  async Task<IActionResult> storyCreate(CreateStoryDto createStoryDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            int storyId = await _storyService.CreatStoryAsync(createStoryDto);

            return RedirectToAction("Index", "Home");
        }
    }
}
