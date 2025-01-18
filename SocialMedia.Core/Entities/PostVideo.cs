using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class PostVideo : BaseAuditableEntity
{
    public int PostId { get; set; }
    public string VideoUrl { get; set; } = null!;
    public Post Post { get; set; } = null!;
}
