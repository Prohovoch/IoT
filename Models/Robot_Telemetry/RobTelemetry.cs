using IoT.Models.Robots;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoT.Models.RobotTelemetry
{
    [Table("rob_telemetry")]
    public class RobTelemetry
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public required Robot RobotId { get; set; }

        public string? Dev_Type { get; set; }

        public IDictionary<string, object>? Telemetry { get; set; }

    }
}
