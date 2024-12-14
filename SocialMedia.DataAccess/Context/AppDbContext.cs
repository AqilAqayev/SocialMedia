
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using System.Reflection.Emit;

namespace SocialMedia.DataAccess.Context;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostImage> PostImages { get; set; }
    public DbSet<PostVideo> PostVideos { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentLike> CommentLikes { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<StoryVideo> StoryVideos { get; set; }
    public DbSet<Message> messages { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.Entity<Comment>()
    //   .HasOne(c => c.Post)
    //   .WithMany(p => p.Comments)
    //   .HasForeignKey(c => c.PostId)
    //   .OnDelete(DeleteBehavior.Restrict);


    //    builder.Entity<Comment>()
    //    .HasOne(c => c.User)
    //    .WithMany()
    //    .HasForeignKey(c => c.UserId)
    //    .OnDelete(DeleteBehavior.Restrict);
    //}
}
