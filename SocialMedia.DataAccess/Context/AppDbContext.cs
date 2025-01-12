
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
    public DbSet<Message> Messages { get; set; }
    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<AppUserChat> AppUserChats { get; set; } = null!;
    public DbSet<Follow> Follows { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }
    public DbSet<FollowConnection> FollowConnections { get; set; }
    public DbSet<SendNatfication> SendNatfications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostLike>()
           .HasOne(pl => pl.Post)
           .WithMany(p => p.PostLikes)
           .HasForeignKey(pl => pl.PostId);

        modelBuilder.Entity<SendNatfication>()
           .HasOne(sn => sn.User)
           .WithMany()
           .HasForeignKey(sn => sn.SenderId);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.AddSeedData();
        base.OnModelCreating(modelBuilder);
    }
}
