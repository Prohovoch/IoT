using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemetryReq
    {
        public Guid DeviceId { get; set; }
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string? DevType { get; set; }

        public IDictionary<string, Object>? Telemetry { get; set; }
    
    }
}
