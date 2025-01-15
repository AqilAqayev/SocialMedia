using Microsoft.AspNetCore.SignalR;

namespace SocalMedia.Business.Hubs;

public class CommentHub : Hub
{
    public async Task NotifyCommentAdded(string postId, string commentHtml)
    {
        await Clients.Group(postId).SendAsync("ReceiveComment", commentHtml);
    }

    public async Task NotifyReplyAdded(string postId, string replyHtml)
    {
        await Clients.Group(postId).SendAsync("ReceiveReply", replyHtml);
    }

    public async Task JoinPostGroup(string postId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, postId);
    }
}
