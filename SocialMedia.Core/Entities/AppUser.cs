using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string NickName { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public int FollowerCount { get; set; } = 0;
        public int FollowingCount { get; set; } = 0;
        public int PostCount { get; set; } = 0;
        public string? Biography { get; set; } 
        public bool IsActive { get; set; }
        public GenderType Gender { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool IsDisabled { get; set; } = false;

    }

}
