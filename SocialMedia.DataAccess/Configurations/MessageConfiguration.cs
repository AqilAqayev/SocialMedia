using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.DataAccess.Configurations;

internal class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(m => m.Text)
            .IsRequired()
            .HasMaxLength(200000);

        builder.Property(m => m.IsDelete)
            .HasDefaultValue(false);
    }
}
