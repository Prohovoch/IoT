using IoT.DTO.DeviceTelemetry;
namespace IoT.DTO.Devices
{
    public class DeviceResponse
    {
        public Guid Id { get; init; }
        public string? DevAlias { get; init; }
        public Guid HubId { get; init; }

    }

    public class DeviceResponseExtra : DeviceResponse
    {
        IEnumerable<DeviceTelemetryResp>? DevTelem { get; init; }

    }
}
