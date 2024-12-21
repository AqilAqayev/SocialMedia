using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class Chat : BaseEntity
{
    public string? Name { get; set; }
    public List<AppUserChat> AppUserChats { get; set; } = [];
    public List<Message> Messages { get; set; } = [];
    public DateTime CreatedTime { get; set; }
    public bool IsDeleted { get; set; } = false;
}
