using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.RobotTelemetry
{
    public class RobotTelemetryUp
    
    {
        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 symbols.")]
        public string? RobotType { get; set; }
        
        

    }
}
