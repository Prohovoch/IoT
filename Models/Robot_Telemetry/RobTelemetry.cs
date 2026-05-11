using IoT.Models.Robots;
using System.ComponentModel.DataAnnotations.Schema;


namespace IoT.Models.RobotTelemetry
{

    public class RobTelemetryEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public  Guid RobotId { get; set; }
        public RobotEntity Robot { get; set; } = null!;
        public string? DevType { get; set; }
        // JSONB for postgresql

        public Dictionary<string, Object>? Telemetry { get; set; }

    }
}
