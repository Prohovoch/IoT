using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;


namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemetryReq
    {
        
        [MaxLength(50, ErrorMessage = "More than 50 chars")]
        public string? DevType { get; set; }
        public float? Temp { get; set; }
        public float? Press { get; set; }

        public int? BattLevel { get; set; }
        public string? Status { get; set; }



    }
}
