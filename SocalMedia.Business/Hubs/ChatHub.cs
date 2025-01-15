using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SocalMedia.Business.StaticFiles;
using System.Security.Claims;

namespace SocalMedia.Business.Hubs;

public class ChatHub : Hub
{
    private readonly IHttpContextAccessor _contextAccessor;

    public ChatHub(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public async Task SendMessage(string chatId, string message, string senderId)
    {
        // Mesaj gönderildiğinde tüm kullanıcılara bildir
        await Clients.Group(chatId).SendAsync("ReceiveMessage", new
        {
            ChatId = chatId,
            Message = message,
            SenderId = senderId,
            CreatedTime = DateTime.UtcNow
        });
    }

    public async Task MarkAsRead(string chatId, string userId)
    {
        // Okunmamış mesajlar bildirimi
        await Clients.Group(chatId).SendAsync("MessagesMarkedAsRead", chatId, userId);
    }

    public override async Task OnConnectedAsync()
    {
        var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }

        await base.OnDisconnectedAsync(exception);
    }
}
