using IoT.Models.Hubs;
using IoT.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoT.Configuration.EntityConfiguration.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure (EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users", "ethernet");
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.Hubs)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(u => u.Surname).IsRequired().HasColumnName("Surname").HasMaxLength(50);
            builder.Property(u => u.Age).HasColumnName("age");

        }
    }
}
