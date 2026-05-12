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

        [Range (0, 100, ErrorMessage ="Only between 0 and 100")]
        public int? BattLevel { get; set; }
        public string? Status { get; set; }



    }
}
