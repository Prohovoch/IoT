namespace IoT.DTO.Devices
{
    public class DeviceResponse
    {
        public string? DevAlias { get; init; }
        public Guid HubId { get; init; }

    }

    public class DeviceResponseExtra : DeviceResponse
    {
        // ....
        // ...

    }
}
