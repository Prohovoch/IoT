using IoT.Models.Devices;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;


namespace IoT.Models.DeviceTelemetry
{
   
    public class DevTelemetryEntity
    {
        
        public Guid Id { get; set; } = Guid.CreateVersion7();


        public Guid DeviceId { get; set; }
        public DeviceEntity Device { get; set; } = null!;
        public string? DevType { get; set; }
        // JSONB for postgres
        public JsonDocument? Telemetry { get; set; }
    }
}
