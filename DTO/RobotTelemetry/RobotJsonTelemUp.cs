using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.RobotTelemetry
{
    public class RobotJsonTelemUp
    
    {
        [Required]
        public IDictionary<string, Object>? Telemetry { get; set; }
    }
}
