using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace IoT.DTO.RobotTelemetry
{
    public class RobotJsonTelemUp
    
    {
        [Required]
        public JsonDocument? Telemetry { get; set; }
    }
}
