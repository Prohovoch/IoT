using System.Text.Json;

namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemResponse
    {
        public Guid Id { get; init; }
        public Guid RobotId { get; init; }

        public string? RobotType { get; init; }

        public IDictionary<string, Object>? Telemetry { get; init; }
    }
}
