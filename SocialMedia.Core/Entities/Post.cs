using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class Post : BaseAuditableEntity
{
    public string UserId { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Count { get; set; } 
    public int CommentCount { get; set; } 
    public AppUser User { get; set; } = null!;
    public List<PostImage> PostImages { get; set; } = [];
    public ICollection<PostVideo> PostVideos { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<PostLike> PostLikes { get; set; } = [];
} 
