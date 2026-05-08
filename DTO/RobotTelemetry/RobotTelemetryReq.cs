using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemetryReq
    {
        public Guid RobotId { get; set; }

        [MaxLength(50, ErrorMessage ="more than 50 chars.")]
        public string? RobotType { get; set; }

        public IDictionary<string, Object>? Telemetry { get; set; }

    }
}
