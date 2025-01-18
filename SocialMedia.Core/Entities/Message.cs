using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class Message : BaseAuditableEntity
{
    public string Text { get; set; } = null!;
    public AppUser Sender { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
    public int ChatId { get; set; }
    public bool IsRead { get; set; } = false;
}