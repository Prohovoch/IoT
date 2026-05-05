using System.ComponentModel.DataAnnotations.Schema;
using IoT.Models.DeviceTelemetry;
using IoT.Models.Hubs;

namespace IoT.Models.Devices
{
    [Table("Devices")]
    public class Device
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public Hub HubId { get; set; } = null!;

        public string? DevAlias {  get; set; }

        public DevTelemetry? DeviceTelemetry {  get; set; }
    }
}
