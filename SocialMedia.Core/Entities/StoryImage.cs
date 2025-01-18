using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class StoryImage: BaseAuditableEntity
{
    public int StoryId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public Story Story { get; set; } = null!;
}
