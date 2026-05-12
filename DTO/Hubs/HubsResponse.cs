using IoT.DTO.Devices;
using IoT.DTO.Robots;
namespace IoT.DTO.Hubs
{
    public class HubsResponse
    {
        public Guid Id { get; init; }
        public string? HubAlias { get; init; }

        public bool? IsActive { get; init; }
        
        public Guid UserId { get; init; }
    }

    public class HubsResponseExtra : HubsResponse
    {
        public IEnumerable<DeviceResponse>? Devices { get; init; }
        public IEnumerable<RobotResponse>? Robots { get; init; }
        // ICollection<...>  Robots {get; init} = new List<Robots>()
    }
}
