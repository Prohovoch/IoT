using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemetryReq
    {
       

        public string? RobotType { get; set; }

        public string? Status { get; set; }
        public int? PosX { get; set; }
        public int? PosY { get; set; }
        
        public int? Battery { get; set; } 
        public float? Speed { get; set; }

    }
}
