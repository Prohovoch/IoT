using IoT.Models.Hubs;
using IoT.Models.RobotTelemetry;

namespace IoT.Models.Robots
{
    public class Robot
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();

        public Guid HubId { get; set; }

        public Hub Hub { get; set; } = null!;
        public string? Dev_Alias { get; set; }

        /*
       * 1 to 1 relation ship
       */
        public RobTelemetry? Telemetry { get; set; }
    }
}
