using Cafe.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Database.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes"); 
        
        builder.HasKey(d => d.Id)
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        
        builder.Property(d => d.Title)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.HasIndex(d => d.Title)
            .IsUnique();

        builder.Property(d => d.Description)
            .IsRequired(); 

        builder.Property(d => d.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(d => d.ImageUrl);
        
        builder.Property(d => d.CreateDateTime)
            .IsRequired();

        builder.Property(d => d.UpdateDateTime)
            .IsRequired();
        
        builder.HasMany(u => u.OrderItems)
            .WithOne(o => o.Dish)
            .HasForeignKey(o => o.DishId);
    }
}