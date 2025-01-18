using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class PostImage : BaseAuditableEntity
    {
        public int PostId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public Post Post { get; set; } = null!;
    }
}
