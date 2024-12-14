using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.DataAccess.Configurations;

internal class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
{
    public void Configure(EntityTypeBuilder<PostImage> builder)
    {
        
        builder.Property(pi => pi.ImageUrl)
            .IsRequired()
            .HasMaxLength(50000);
    }
}
