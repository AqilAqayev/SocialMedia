using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class StoryVideo : BaseEntity
    {
        public int StoryId { get; set; }
        public string VideoUrl { get; set; } = null!;
        public Story Story { get; set; } = null!;
    }
}
