using IoT.Models.Devices;
using IoT.Models.DeviceTelemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoT.Configuration.EntityConfiguration.DeviceTelemetry
{
    public class DeviceTelemetryConfiguration : IEntityTypeConfiguration<DevTelemetryEntity>
    {
        public void Configure(EntityTypeBuilder<DevTelemetryEntity> builder)
        {
            builder.ToTable("dev_telemetry", "ethernet");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Device)
                .WithOne(d => d.Telemetry)
                .HasForeignKey<DevTelemetryEntity>(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.DeviceId).IsRequired().HasColumnName("device_id");
            builder.Property(t => t.DevType).HasColumnName("dev_type").HasMaxLength(50);
            builder.Property(t => t.Telemetry).HasColumnName("telemetry").HasColumnType("jsonb");

        }
    }
}
