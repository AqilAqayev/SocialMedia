using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class PostLike : BaseAuditableEntity
{
    public int PostId { get; set; }
    public string UserId { get; set; } = null!;
    public Post Post { get; set; } = null!;
    public AppUser User { get; set; } = null!;
}
