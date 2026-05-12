using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemetryReq
    {
        public Guid RobotId { get; set; }

        [MaxLength(50, ErrorMessage ="more than 50 chars.")]
        public string? RobotType { get; set; }

        public IDisposable? Telemetry { get; set; }

    }
}
