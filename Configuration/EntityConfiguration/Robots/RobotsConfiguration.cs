using IoT.Models.Robots;
using IoT.Models.RobotTelemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoT.Configuration.EntityConfiguration.Robots
{
    public class RobotConfiguration : IEntityTypeConfiguration<RobotEntity>
    {
        public void Configure(EntityTypeBuilder<RobotEntity> builder)
        {
            builder.ToTable("robots", "ethernet");
            builder.HasKey(r => r.Id);
            builder.HasOne(t => t.Telemetry)
                .WithOne(t => t.Robot)
                .HasForeignKey<RobTelemetryEntity>(t => t.RobotId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(r => r.DevAlias).IsRequired().HasMaxLength(50).HasColumnName("dev_alias");
            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.HubId).IsRequired().HasColumnName("hub_id");
           

        }
    }
}
