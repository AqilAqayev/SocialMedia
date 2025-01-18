using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Story : BaseAuditableEntity
    {
        public string UserId { get; set; } = null!;
        public bool IsPrivate { get; set; }
        public AppUser User { get; set; } = null!;
        public ICollection<StoryVideo> StoryVideos { get; set; } = [];
        public ICollection<StoryImage> StoryImages { get; set; } = [];
    }
}
