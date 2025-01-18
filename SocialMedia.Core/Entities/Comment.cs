using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public AppUser User { get; set; } = null!;
        public string AppUserId { get; set; } = null!;
        public int  PostId { get; set; }
        public Post Post { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int? Rating { get; set; }
        public int? ParentId { get; set; }
        public Comment? Parent { get; set; } = null!;
        public List<Comment> Children { get; set; } = [];

    }
}
