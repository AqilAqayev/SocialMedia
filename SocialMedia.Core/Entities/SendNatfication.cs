using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class SendNatfication : BaseEntity
{
    public string UserId { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public AppUser? User { get; set; } = null!;
}
