using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities
{
    public class Message: BaseEntity
    {
        public string Text { get; set; } = null!;
        public string ToUserId { get; set; } = null!;
        public string FromUserId { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public bool IsDelete { get; set; } 
        public AppUser ToUser { get; set; }=null!;
        public AppUser FromUser { get; set; } = null!;
    }

}
