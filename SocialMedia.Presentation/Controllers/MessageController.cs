using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocalMedia.Business.Dtos.MessageDtos;
using SocalMedia.Business.Hubs;
using SocalMedia.Business.Services.Abstractions;
using SocalMedia.Business.StaticFiles;
using SocalMedia.Business.UiServices.Abstractions;
using SocialMedia.Core.Entities;
using SocialMedia.Presentation.Extensions;
using System.Security.Claims;
namespace SocialMedia.Presentation.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;
        private readonly IAccountService _accountService;
        public MessageController(UserManager<AppUser> userManager, IHubContext<ChatHub> chatHubContext, IChatService chatService, IMessageService messageService, IAccountService accountService)
        {
            _userManager = userManager;
            _chatHubContext = chatHubContext;
            _chatService = chatService;
            _messageService = messageService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var chat = await _chatService.GetChatIfExistsAsync(id);

            chat.Id = id;
            return View(chat);
        }
      
        [HttpPost]

        public async Task<IActionResult> SendMessage([FromBody]SendMessageDto dto)
        {
            var userId =  _accountService.GetId();
            var message = await _chatService.CreateMessage(dto.Text, dto.ChatId);
            message.Chats = null;
             await _chatService.SendMessageAsync(dto.ChatId,dto.Text, userId, message);
          
            return Json(message);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = _accountService.GetId();

            await _chatService.DeleteChatIfNoMutualFollowAsync(userId);
            
            return RedirectToAction("Index", "Home");
        }
    }
}