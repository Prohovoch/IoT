using IoT.Models.Devices;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoT.Models.DeviceTelemetry
{
    [Table("dev_telemetry")]
    public class DevTelemetry
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public required Device DeviceId { get; set; }
        public string? DevType { get; set; }

        public IDictionary<string, object>? Telemetry { get; set; }
    }
}
