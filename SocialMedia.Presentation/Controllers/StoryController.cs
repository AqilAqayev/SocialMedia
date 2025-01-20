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

        public async Task<IActionResult> Index()
        {
            var userStories = await _storyService.GetAllUserStoriesAsync();

            var allStories = userStories.Select(user => new
            {
                userName = user.UserName,
                profilePicture = user.ProfilePhotoUrl,
                stories = user.Stories.SelectMany(story => story.StoryImages.Select(image => new { url = image, type = "image" })
                                     .Concat(story.StoryVideos.Select(video => new { url = video, type = "video" })))
            }).ToList();

            ViewBag.AllStoriesJson = Newtonsoft.Json.JsonConvert.SerializeObject(allStories);

            return View(userStories);
        }



        [HttpPost]
        [Authorize]

        public async Task<IActionResult> storyCreate(CreateStoryDto createStoryDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            int storyId = await _storyService.CreatStoryAsync(createStoryDto);

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _storyService.DeleteAsync(id);

            return RedirectToAction("Index", "Profile");
        }
    }
}
