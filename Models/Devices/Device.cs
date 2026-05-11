using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using IoT.Models.DeviceTelemetry;
using IoT.Models.Hubs;

namespace IoT.Models.Devices
{
    [Table("Devices")]
    public class DeviceEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();

        public Guid HubId { get; set; }
        
        public Hub Hub { get; set; } = null!;

        public string? DevAlias {  get; set; }

        /*
         * 1 to 1 relation ship
         */
        public DevTelemetryEntity? Telemetry {  get; set; }
    }
}
