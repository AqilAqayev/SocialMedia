using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SocalMedia.Business.Exceptions;
using SocalMedia.Business.Services.Abstractions;

namespace SocialMedia.Presentation.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly IChatService _chatService;

    public HeaderViewComponent(IChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<ViewViewComponentResult> InvokeAsync()
    {
        string userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            throw new SignInException("User is not authenticated.");
        }

        var userChats = await _chatService.GetUserChatsAsync(userId);

        return View(userChats);
    }
}
