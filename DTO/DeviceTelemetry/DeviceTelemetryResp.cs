
using System.Text.Json;

namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemetryResp
    {
        public Guid Id { get; init; }
        public Guid DeviceId { get; init; }
                

        public string? DevType { get; init; }
        
        public float? Temp { get; init; }
        public float? Press { get; init; }

        public int? BattLevel { get; init; }
        public string? Status { get; init; }
    }
}
