using IoT.Models.RobotTelemetry;
using IoT.Models.Robots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoT.Configuration.EntityConfiguration.RobotTelemetry
{
    public class RobotTelemetryConfiguration : IEntityTypeConfiguration<RobTelemetryEntity>
    {
        public void Configure(EntityTypeBuilder<RobTelemetryEntity> builder)
        {
            builder.ToTable("rob_telemetry", "ethernet");
            builder.HasKey(rt => rt.Id);
            builder.HasOne(rt => rt.Robot)
                .WithOne(r => r.Telemetry)
                .HasForeignKey<RobTelemetryEntity>(rt => rt.RobotId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(rt => rt.Id).HasColumnName("id");
            builder.Property(rt => rt.RobotId).IsRequired().HasColumnName("robot_id");
            builder.Property(rt => rt.DevType).HasColumnName("robot_type").HasMaxLength(50);
            builder.Property(rt => rt.Telemetry).HasColumnName("telemetry").HasColumnType("jsonb");

        }
    }
    
    
}
