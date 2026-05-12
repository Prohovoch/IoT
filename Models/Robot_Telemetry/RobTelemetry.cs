using IoT.Models.Robots;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;


namespace IoT.Models.RobotTelemetry
{

    public class RobTelemetryEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public  Guid RobotId { get; set; }
        public RobotEntity Robot { get; set; } = null!;
        public string? DevType { get; set; }
        // JSONB for postgresql

        public JsonDocument? Telemetry { get; set; }

    }
}
