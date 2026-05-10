
namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemetryResp
    {
        public Guid Id { get; init; }
        public Guid DeviceId { get; init; }
        public IDictionary<string, Object>? Telemetry { get; init; }

        public string? DevType { get; init; }
    }
}
