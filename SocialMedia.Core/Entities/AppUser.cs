using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string NickName { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public int PostCount { get; set; }
        public string Biography { get; set; } = null!;
        public bool IsActive { get; set; }
        public GenderType Gender { get; set; }
        public bool IsPrivate { get; set; }
    }

}
