using Microsoft.AspNetCore.Mvc;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.UiServices.Abstractions;

namespace SocialMedia.Presentation.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IAccountService _accountService;

        public ChatController(IChatService chatService, IAccountService accountService)
        {
            _chatService = chatService;
            _accountService = accountService;
        }

        public async Task<IActionResult> CreateChat(string userId)
        {
            var chat = await _chatService.CreateChatIfMutualFollowAsync(userId);

            return RedirectToAction("Detail", new { id = chat.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _chatService.DeleteAsync(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
