using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace IoT.DTO.RobotTelemetry
{
    public class RobotJsonTelemUp
    
    {
        [Required]
        public IDictionary<string, Object>? Telemetry { get; set; }
    }
}
