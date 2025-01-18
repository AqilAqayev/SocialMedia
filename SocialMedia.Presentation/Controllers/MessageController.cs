using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocalMedia.Business.Hubs;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.StaticFiles;
using SocialMedia.Core.Entities;
using SocialMedia.DataAccess.Context;
using System.Security.Claims;
namespace SocialMedia.Presentation.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly IChatService _chatService;
        public MessageController(UserManager<AppUser> userManager, AppDbContext context, IHubContext<ChatHub> chatHubContext, IChatService chatService)
        {
            _userManager = userManager;
            _context = context;
            _chatHubContext = chatHubContext;
            _chatService = chatService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest();
            var chat = await _chatService.GetChatIfExistsAsync(id, userId);

            if (chat is null)
                return NotFound();
            return View(chat);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(int chatId, string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest();
            var chat = await _chatService.GetChatIfExistsAsync(chatId, userId);
            if (chat is null)
                return NotFound();
            Message message = new()
            {
                Text = text,
                ChatId = chatId,
                SenderId = userId,
            };
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            message.Chat = null;
            foreach (var userChat in chat.AppUserChats.Where(x => x.AppUserId != userId))
            {
                var connection = HubDatas.Connections.FirstOrDefault(x => x.UserId == userChat.AppUserId);
                if (connection is { })
                {
                    foreach (var id in connection.ConnectionIds)
                    {
                        await _chatHubContext.Clients.Client(id).SendAsync("ReceiveMessage", message);
                    }
                }
            }
            return Json(message);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest();
            var chat = await _chatService.GetChatIfExistsAsync(id, userId);
            if (chat is null)
                return NotFound();
            await _chatService.DeleteChatIfNoMutualFollowAsync(userId);
            return RedirectToAction("Index", "Home");
        }
    }
}