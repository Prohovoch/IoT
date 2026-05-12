using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace IoT.DTO.RobotTelemetry
{
    public class RobotJsonTelemUp
    
    {
        [Required]
        public JsonNode? Telemetry { get; set; }
    }
}
