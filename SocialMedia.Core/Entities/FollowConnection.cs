using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class FollowConnection : BaseAuditableEntity
{
    public string? UserId { get; set; }
    public string? ConnectionId { get; set; }
    public AppUser? User { get; set; }
}
