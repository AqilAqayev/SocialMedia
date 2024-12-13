using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public int PostId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public int LikeCount { get; set; }

        public AppUser User { get; set; } = null!;
        public Post Post { get; set; } = null!;
        public ICollection<CommentLike> CommentLikes { get; set; } = [];
    }
}
