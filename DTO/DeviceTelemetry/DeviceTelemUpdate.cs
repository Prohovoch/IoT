using System.ComponentModel.DataAnnotations;


namespace IoT.DTO.DeviceTelemetry
{
    public class DeviceTelemUpdate
    {
        [Required]
        [MaxLength(50, ErrorMessage ="More than 50 chars")]
        public string? DevType { get; set; }

        

    }
}
