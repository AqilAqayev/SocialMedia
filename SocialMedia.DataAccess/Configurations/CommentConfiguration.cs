using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.DataAccess.Configurations;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Text)
            .IsRequired()
            .HasMaxLength(100000); 

        builder.Property(c => c.CreatedTime)
            .IsRequired();

        //builder.Property(c => c.LikeCount)
        //    .HasDefaultValue(0);
    }
}