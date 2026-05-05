using System.ComponentModel.DataAnnotations.Schema;
using IoT.Models.Devices;
using IoT.Models.Robots;
using IoT.Models.Users;

namespace IoT.Models.Hubs
{
    [Table("Hubs")]
    public class Hub
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public required User UserId { get; set; } = null!;
        public bool HubIsActive { get; set; }

        public string? HubAlias { get; set; }

        public List<Device>? Devices;
        public List<Robot>? Robots;


    }
}
