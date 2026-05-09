using IoT.Models.Devices;
using System.ComponentModel.DataAnnotations.Schema;


namespace IoT.Models.DeviceTelemetry
{
    [Table("dev_telemetry")]
    public class DevTelemetry
    {
        
        public Guid Id { get; set; } = Guid.CreateVersion7();


        public Guid DeviceId { get; set; }
        public Device Device { get; set; } = null!;
        public string? DevType { get; set; }
        // JSONB for postgres
        public Dictionary<string, Object>? Telemetry { get; set; }
    }
}
