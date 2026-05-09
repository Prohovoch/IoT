using IoT.Models.Robots;
using System.ComponentModel.DataAnnotations.Schema;


namespace IoT.Models.RobotTelemetry
{
    [Table("rob_telemetry")]
    public class RobTelemetry
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public  Guid RobotId { get; set; }
        public Robot Robot { get; set; } = null!;
        public string? DevType { get; set; }
        // JSONB for postgresql

        public Dictionary<string, Object>? Telemetry { get; set; }

    }
}
