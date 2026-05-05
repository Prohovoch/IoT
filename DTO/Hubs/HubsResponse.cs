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
        // ICollection<...>  Devices { get; init } = new List<Hub>();
        // ICollection<...>  Robots {get; init} = new List<Robots>()
    }
}
