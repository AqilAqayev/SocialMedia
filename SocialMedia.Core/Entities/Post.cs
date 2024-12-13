using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Post : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public bool IsDelete { get; set; }
        public AppUser User { get; set; } = null!;
        public ICollection<PostImage> PostImages { get; set; } = [];
        public ICollection<PostVideo> PostVideos { get; set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];
    }
}
