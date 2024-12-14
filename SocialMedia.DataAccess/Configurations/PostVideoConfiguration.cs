using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.DataAccess.Configurations;

internal class PostVideoConfiguration : IEntityTypeConfiguration<PostVideo>
{
    public void Configure(EntityTypeBuilder<PostVideo> builder)
    {
        builder.Property(pv => pv.VideoUrl)
            .IsRequired()
            .HasMaxLength(500000);
    }
}
