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

            builder.Property(rt => rt.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(rt => rt.RobotId).IsRequired().HasColumnName("robot_id");
            builder.Property(rt => rt.DevType).HasColumnName("robot_type").HasMaxLength(50).HasColumnType("varchar");
            builder.Property(rt => rt.Status).HasColumnName("status").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(rt => rt.BatteryLevel).HasColumnName("battery_level").HasColumnType("int");
            builder.Property(rt => rt.Speed).HasColumnType("decimal").HasPrecision(18, 4).HasColumnName("speed");
            builder.Property(rt => rt.PositionX).HasColumnName("position_x").HasColumnType("decimal").HasPrecision(18, 4);
            builder.Property(rt => rt.PositionY).HasPrecision(18, 4).HasColumnName("position_y").HasColumnType("decimal");

        }
    }
    
    
}
