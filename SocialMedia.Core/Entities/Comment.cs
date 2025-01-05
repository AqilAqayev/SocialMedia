using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Comment : BaseEntity
    {
        public AppUser AppUser { get; set; } = null!;
        public string AppUserId { get; set; } = null!;
        public int  PostId { get; set; }
        public Post Post { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int? Rating { get; set; }
        public int? ParentId { get; set; }
        public Comment? Parent { get; set; } = null!;
        public List<Comment> Children { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
