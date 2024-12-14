
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using System.Reflection;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.AddSeedData();
        base.OnModelCreating(modelBuilder);
    }
}
