using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using SocalMedia.Business.Dtos.HeaderDtos;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;
using SocialMedia.Core.Entities;

namespace SocialMedia.Presentation.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly IChatService _chatService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ISendNatficationService _sendNatficationService;

    public HeaderViewComponent(IChatService chatService, UserManager<AppUser> userManager, ISendNatficationService sendNatficationService)
    {
        _chatService = chatService;
        _userManager = userManager;
        _sendNatficationService = sendNatficationService;
    }

    public async Task<ViewViewComponentResult> InvokeAsync()
    {
        var userId = HttpContext.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new SignInException("User is not authenticated.");
        }

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        var userChats = await _chatService.GetUserChatsAsync(userId);
        var followRequest = await _sendNatficationService.GetAllAsync(
     x => x.UserId == userId,
     include: query => query.Include(n => n.User));

        var headerDto = new HeaderDto
        {
            Chats = userChats,

            Username = user.UserName,
            ProfileUrl = user.ProfilePhotoUrl,
            SendNatfication = followRequest,
            UserId = user.Id

        };

        return View(headerDto);
    }
}
