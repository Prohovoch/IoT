using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceJsonTelemUp
    {
        [Required]
        public IDictionary<string, Object>? Telemetry { get; set; }
    }
}
