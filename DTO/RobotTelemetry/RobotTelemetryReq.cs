using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemetryReq
    {

        [MaxLength(50)]
        public string? RobotType { get; set; }
        [MaxLength(50)]
        public string? Status { get; set; }
        [Range(-10000, 10000)]
        public float? PosX { get; set; }
        [Range(-10000, 10000)]
        public float? PosY { get; set; }
        [Range(0, 100)]
        public int? Battery { get; set; } 
        public float? Speed { get; set; }

    }
}
