using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Story : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public bool IsPrivate { get; set; }

        public AppUser User { get; set; } = null!;
        public ICollection<StoryVideo> StoryVideos { get; set; } = [];
    }
}
