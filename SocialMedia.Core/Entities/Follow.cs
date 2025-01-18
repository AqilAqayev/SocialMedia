using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class Follow : BaseAuditableEntity
{
    public string FollowerId { get; set; } = null!;
    public string FollowingId { get; set; } = null!;
    public AppUser Follower { get; set; } = null!;
    public AppUser Following { get; set; } = null!;
    public bool Status { get; set; }
}