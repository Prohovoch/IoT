using System.Text.Json;

namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemetryResp
    {
        public Guid Id { get; init; }
        public Guid DeviceId { get; init; }
        public JsonDocument? Telemetry { get; init; }

        public string? DevType { get; init; }
    }
}
