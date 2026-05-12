

using System.Text.Json;

namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemResponse
    {
        public Guid Id { get; init; }
        public Guid RobotId { get; init; }

        public string? RobotType { get; init; }

        public string? Status { get; init; }
        public int? PosX { get; init; }
        public int? PosY { get; init; }

        public int? Battery { get; init; }

        public float? Speed { get; init;  }
    }
}
