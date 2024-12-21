using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class Message : BaseEntity
{
    public string Text { get; set; } = null!;
    public DateTime CreatedTime { get; set; }
    public AppUser Sender { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
    public int ChatId { get; set; }
    public bool IsDeleted { get; set; } = false;
}
