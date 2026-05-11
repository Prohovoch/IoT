using System.ComponentModel.DataAnnotations.Schema;
using IoT.Models.Devices;
using IoT.Models.Robots;
using IoT.Models.Users;

namespace IoT.Models.Hubs
{
    [Table("Hubs")]
    public class HubEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public Guid UserId { get; set; }
        public bool HubIsActive { get; set; }

        public string? HubAlias { get; set; }

        public User User { get; set; } = null!;

        /*
         * 1 : m relations
         * 1 : m relations
         */
        public List<DeviceEntity>? Devices { get; }
        public List<Robot>? Robots { get; }


    }
}
