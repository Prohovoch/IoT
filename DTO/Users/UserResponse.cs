using IoT.DTO.Hubs;
using IoT.Models.Hubs;

namespace IoT.DTO.Users
{
    public class UserResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string Surname { get; init;  } = null!;
    
        public int? Age { get; init; }
    }

    public class UserResponseHubs : UserResponse
    {
        public IEnumerable<HubsResponse>? Hubs;
    }
}

