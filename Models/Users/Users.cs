
using IoT.Models.Hubs;


namespace IoT.Models.Users
{
    
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();


        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int? Age { get; set; }

        // 1 : m relations
        public List<HubEntity>? Hubs { get; }

    }
}


