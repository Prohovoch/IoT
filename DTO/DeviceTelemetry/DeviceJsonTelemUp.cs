using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceJsonTelemUp
    {
        [Required]
        public JsonDocument? Telemetry { get; set; }
    }
}
