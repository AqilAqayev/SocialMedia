using SocialMedia.Core.Entities.Base;

namespace SocialMedia.Core.Entities;

public class Post : BaseEntity
{
    public string UserId { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Count { get; set; } 
    public int CommentCount { get; set; } 
    public DateTime CreatedTime { get; set; }
    public bool IsDelete { get; set; }
    public AppUser User { get; set; } = null!;
    public List<PostImage> PostImages { get; set; } = [];
    public ICollection<PostVideo> PostVideos { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<PostLike> PostLikes { get; set; } = [];
} 
