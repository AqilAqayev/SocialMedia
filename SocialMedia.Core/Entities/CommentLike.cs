using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class CommentLike : BaseEntity
    {
        public int CommentId { get; set; }
        public string UserId { get; set; } = null!;
        public Comment Comment { get; set; } = null!;
        public AppUser User { get; set; } = null!;
    }
}
