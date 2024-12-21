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

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public override Task OnConnectedAsync()
    {
        var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var connection = HubDatas.Connections.FirstOrDefault(x => x.UserId == userId);
        if (connection is { })
        {
            connection.ConnectionIds.Add(Context.ConnectionId);
        }
        else
        {
            HubDatas.Connections.Add(new() { UserId = userId!, ConnectionIds = [Context.ConnectionId] });
        }

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        HubDatas.Connections.RemoveAll(x => x.UserId == userId);

        return base.OnDisconnectedAsync(exception);
    }
}
