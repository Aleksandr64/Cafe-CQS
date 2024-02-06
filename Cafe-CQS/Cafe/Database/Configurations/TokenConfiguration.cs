using Cafe.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Database.Configurations;

public class TokenConfiguration : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.ToTable("Tokens");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserName)
            .IsRequired();

        builder.Property(t => t.RefreshToken)
            .IsRequired();

        builder.Property(t => t.RefreshTokenExpiredTime)
            .IsRequired();

        builder.HasIndex(t => t.RefreshToken)
            .IsUnique();
    }
}