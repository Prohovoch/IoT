using IoT.Models.Hubs;
using IoT.Models.RobotTelemetry;

namespace IoT.Models.Robots
{
    public class Robot
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();

        public required Hub HubId { get; set; } = null!;

        public String? Dev_Alias { get; set; }

        public RobTelemetry? RobTelemetry { get; set; }
    }
}
